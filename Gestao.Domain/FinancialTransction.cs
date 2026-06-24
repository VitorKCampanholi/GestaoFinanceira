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
        [RequiredIfAmoundPaidFilled]
        public decimal? Amount { get; set; }
        public Recurrence Repeat { get; set; }
        [RequiredRepeatTimes]
        public int? RepeatTimes { get; set; }
        public decimal? InteresPenalty { get; set; }
        public decimal? Discount {  get; set; }       
        public decimal? AmoundPaid { get; set; }
        public string? Observation {  get; set; }
        public DateTimeOffset CreateDate {  get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        [RequiredIfAmoundPaidFilled]
        public DateTimeOffset? PaymentDate { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório!")]        
        public DateTimeOffset ReferenceDate { get; set; }
        public DateTimeOffset? DueDate { get; set; }
        public ICollection<Document>? Documents {  get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public int? AccountId { get; set; }
        public Account? Account { get; set; }  
        public int? CategoryId  { get; set; }
        public Category? Category { get; set; }    



    }
}
