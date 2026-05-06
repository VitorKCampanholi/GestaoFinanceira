using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Domain
{
    public class DocumentAttachment
    {
        public int Id { get; set; }
        public string Path { get; set; } = null!;
        public int? FinancialTransactionId { get; set; }
        public FinancialTransction? FinancialTransaction { get; set; }
    }
}
