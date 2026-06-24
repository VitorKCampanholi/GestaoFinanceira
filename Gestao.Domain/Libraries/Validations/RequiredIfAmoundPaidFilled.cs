using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Domain.Libraries.Validations
{
    internal class RequiredIfAmoundPaidFilled : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            FinancialTransction transction = (FinancialTransction)validationContext.ObjectInstance;

            if (transction.AmoundPaid.HasValue)
            {
                if (value is null)
                    return new ValidationResult("O Campo é orbigatório!", new[] { validationContext.MemberName! });
            }
            return ValidationResult.Success;
        }
    }
}
