using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Domain.Libraries.Validations
{
    internal class RequiredRepeatTimesAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            FinancialTransction transction = (FinancialTransction)validationContext.ObjectInstance;

            if (transction.Repeat != Enums.Recurrence.None)
            {
                if (value is null)
                    return new ValidationResult("O campo é obrigatóio!", new[] { validationContext.MemberName!});
            }
            return ValidationResult.Success;
        }
    }
}
