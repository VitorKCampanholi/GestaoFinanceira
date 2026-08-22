using Gestao.Domain.Enums;
using Gestao.Domain.Interfaces;
using Gestao.Domain.Libraries.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Domain
{
    public class FinancialTransction : ISoftDelete
    {
        public int Id { get; set; }

        public TypeFinancialTransction TypeFinancialTransction { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [MinLength(3, ErrorMessage = "O Campo deve ter pelo menos {1} caracteres!")]
        public string Description { get; set; } = string.Empty;
        [Range(0.1, 10000000000, ErrorMessage = "O Campo deve ter entre {1} e {2}")]
        [RequiredIfAmoundPaidFilled]       
        public decimal? Amount { get; set; }
        public Recurrence Repeat { get; set; }
        [Range(0.1, 10000000000, ErrorMessage = "O Campo deve ter entre {1} e {2}")]
        [RequiredRepeatTimes]
        public int? RepeatTimes { get; set; }
        [Range(0, 10000, ErrorMessage = "O Campo deve ter entre {1} e {2}")]
        public int? RepeatGroup { get; set; }
        public decimal? InteresPenalty { get; set; }
        [Range(0, 10000000000, ErrorMessage = "O Campo deve ter entre {1} e {2}")]
        [DiscountNotBeGreaterThanAmount]
        public decimal? Discount {  get; set; }
        [Range(0.1, 10000000000, ErrorMessage = "O Campo deve ter entre {1} e {2}")]
        [AmoundPaidValue]
        public decimal? AmoundPaid { get; set; }
        public string? Observation {  get; set; }
        public DateTimeOffset CreateDate {  get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        [RequiredIfAmoundPaidFilled]
        [Range(typeof(DateTimeOffset), "1/1/2000", "1/1/2300", ErrorMessage = "A data deve ser entre {1:dd/MM/yyyy} e {2:dd/MM/yyyy}")]
        public DateTimeOffset? PaymentDate { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [Range(typeof(DateTimeOffset), "1/1/2000","1/1/2300", ErrorMessage = "A data deve ser entre {1:dd/MM/yyyy} e {2:dd/MM/yyyy}")]
        public DateTimeOffset ReferenceDate { get; set; }
        [Range(typeof(DateTimeOffset), "1/1/2000", "1/1/2300", ErrorMessage = "A data deve ser entre {1:dd/MM/yyyy} e {2:dd/MM/yyyy}")]
        [RequiredIfAmoundPaidFilled]
        public DateTimeOffset? DueDate { get; set; }
        public ICollection<Document>? Documents {  get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        [RequiredIfAmoundPaidFilled]
        public int? AccountId { get; set; }
        public Account? Account { get; set; }
        [RequiredIfAmoundPaidFilled]
        public int? CategoryId  { get; set; }
        public Category? Category { get; set; }    



    }
}
