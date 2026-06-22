using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Domain.Enums
{
    public enum Recurrence
    {
        [Display(Name = "Nenhum")]
        None,
        [Display(Name = "Semanalmente")]
        Weekly,
        [Display(Name = "Mensalmente")]
        Monthly,
        [Display(Name = "Anualmente")]
        Yearly
    }
}
