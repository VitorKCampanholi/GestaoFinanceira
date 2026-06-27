using Gestao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Domain
{
    public class Document : ISoftDelete
    {
        public int Id { get; set; }
        public string Path { get; set; } = null!;
        public string Name { get; set; } = null!;  
        public int? FinancialTransactionId { get; set; }
        public FinancialTransction? FinancialTransaction { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public DateTimeOffset CreateDate { get; set; }
    }
}
