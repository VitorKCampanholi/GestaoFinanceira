using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Domain.Libraries.Validations
{
    internal class DiscountNotBeGreaterThanAmountAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            FinancialTransction transction = (FinancialTransction)validationContext.ObjectInstance;

            if (transction.Amount.HasValue && value is not null)
            {
                decimal discount = (decimal)value;
                if (discount > transction.Amount)
                {
                    new ValidationResult("O desconto é maior que o valor da conta!", new[] { validationContext.MemberName! });
                }
            }
            return ValidationResult.Success;
        }
    }
}
