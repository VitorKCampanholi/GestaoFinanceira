using Gestao.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Domain
{
    public class FinancialTransction
    {
        public int Id { get; set; }
        public int Description { get; set; }
        public DateTimeOffset ReferenceDate { get; set; }
        public DateTimeOffset DueDate { get; set; }
        public decimal Amount { get; set; }
        public Recurrence Repeat { get; set; }
        public int RepeatTimes { get; set; }
        public decimal InteresPenalty { get; set; }
        public decimal Discount {  get; set; }
        public DateTimeOffset PaymentDate { get; set; }
        public decimal AmoundPaid { get; set; }
        public string? Observation {  get; set; }
        public DateTimeOffset CreateDate {  get; set; }
        public ICollection<DocumentAttachment>? DocumentAttachments {  get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public int? AccountId { get; set; }
        public Account? Account { get; set; }  
        public int? CategoryId  { get; set; }
        public Category? Category { get; set; }


    }
}
