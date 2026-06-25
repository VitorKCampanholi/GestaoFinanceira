using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Domain.Libraries.Validations
{
    internal class AmoundPaidValueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value == null)
                return ValidationResult.Success;

            FinancialTransction transction = (FinancialTransction)validationContext.ObjectInstance;


            decimal total = 0;
            if (transction.Amount.HasValue)
            {
                total = transction.Amount.Value;
                if (transction.InteresPenalty.HasValue)
                {
                    total += transction.InteresPenalty.Value;
                }
                if (transction.Discount.HasValue)
                {
                    total -= transction.Discount.Value;
                }
                if (total != transction.AmoundPaid)
                {
                    return new ValidationResult($"Valor incorreto, deveria ser: {total.ToString("C")} verifique os campos 'Valor', 'Juros/Multas' e 'Desconto.'", new[] { validationContext.MemberName! });
                }
            }
            return ValidationResult.Success;
        }
    }
}