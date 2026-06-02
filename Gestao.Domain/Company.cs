using GestaoFinanceira.Domain;
using System.ComponentModel.DataAnnotations;

namespace Gestao.Domain
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string LegalName { get; set; } = string.Empty;
        [Required]
        public string TradeName { get; set; } = string.Empty;
        [Required]
        public string TaxId { get; set; } = string.Empty;
        [Required]
        public string PostalCode { get; set; } = string.Empty;
        [Required]
        public string State { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string Neighborhood { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string Complement { get; set; } = string.Empty;
        [Required]
        public DateTimeOffset CreateDate { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
    }
}
