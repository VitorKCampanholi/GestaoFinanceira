using Coravel.Invocable;
using Gestao.Domain;
using Gestao.Domain.Enums;
using GestaoFinanceira.Domain.Repositories;

namespace GestaoFinanceira.libraries.Queues
{
    public class FinancialTransacitonRepeatInvocable : IInvocable, IInvocableWithPayload<FinancialTransction>
    {

        private IFinancialTransactionsRepository _repository;

        public FinancialTransacitonRepeatInvocable(IFinancialTransactionsRepository repository)
        {
            _repository = repository;
        }

        public FinancialTransction Payload { get; set; }

        public async Task Invoke()
        {
            int startPoint = 1;
            int countTranssactionsSameGroup = await _repository.GetCountAssociateTranactionSameGroup(Payload.Id);
            await AssingnRepeatGroupToPayLoad();

            if(countTranssactionsSameGroup == 0)
            {
                await RegisterNewTransaction(startPoint);
            }
            else
            {
                await RegisterNewTransaction(countTranssactionsSameGroup);
            }            
            await TransactionReduction(countTranssactionsSameGroup);

            await RepeatTransactionsRemove(countTranssactionsSameGroup);

        }

        private async Task AssingnRepeatGroupToPayLoad()
        {
            if (Payload.Repeat != Recurrence.None)
            {
                Payload.RepeatGroup = Payload.Id;
                await _repository.Update(Payload);
            }
        }

        private async Task RepeatTransactionsRemove(int countTranssactionsSameGroup)
        {
            if (Payload.Repeat == Gestao.Domain.Enums.Recurrence.None && countTranssactionsSameGroup > 1)
            {
                var transactions = await _repository.GetTransactionsSameGroup(Payload.Id);
                for (int i = 2; i <= countTranssactionsSameGroup; i++)
                {
                    await _repository.Delete(transactions.ElementAt(i-1));
                }
            }
        }

        private async Task TransactionReduction(int countTranssactionsSameGroup)
        {
            if (Payload.Repeat != Gestao.Domain.Enums.Recurrence.None && countTranssactionsSameGroup > Payload.RepeatTimes)
            {
                var transactions = await _repository.GetTransactionsSameGroup(Payload.Id);
                for (int i = countTranssactionsSameGroup; i > Payload.RepeatTimes; i--)
                {
                    await _repository.Delete(transactions.ElementAt(i-1));
                }
            }
        }

        private async Task RegisterNewTransaction(int startPoint)
        {
            if (Payload.Repeat != Recurrence.None)
            {
                var repeatTimes = Payload.RepeatTimes - 1;

                for (int i = startPoint; i <= repeatTimes; i++)
                {
                    var financial = new FinancialTransction();
                    financial.TypeFinancialTransction = Payload.TypeFinancialTransction;
                    financial.Description = Payload.Description;
                    financial.ReferenceDate = IncrementDate(Payload.Repeat, i, Payload.ReferenceDate);
                    financial.DueDate = Payload.DueDate.HasValue ? IncrementDate(Payload.Repeat, i, Payload.DueDate.Value) : null;
                    financial.Amount = Payload.Amount;
                    financial.RepeatGroup = Payload.Id;
                    financial.Repeat = Recurrence.None;
                    financial.RepeatTimes = null;
                    financial.CreateDate = DateTimeOffset.Now;

                    financial.CompanyId = Payload.CompanyId;
                    financial.AccountId = Payload.AccountId;
                    financial.CategoryId = Payload.CategoryId;


                    await _repository.Add(financial);
                }
            }
        }
        private DateTimeOffset IncrementDate(Recurrence repeat, int count, DateTimeOffset date)
        {
            DateTimeOffset dateModified = date;
            switch (repeat)
            {
                case Recurrence.Weekly:
                    dateModified = date.AddDays(7 * count);
                    break;

                case Recurrence.Monthly:
                    dateModified = date.AddMonths(count);
                    break;

                case Recurrence.Yearly:
                    dateModified = date.AddYears(count);
                    break;
                default:
                    break;
            }
            return dateModified;
        }
    }
}
