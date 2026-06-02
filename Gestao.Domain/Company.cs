using GestaoFinanceira.Domain;
using System.ComponentModel.DataAnnotations;
using Gestao.Domain.Libraries.Validations;

namespace Gestao.Domain
{
    public class Company
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo 'Razão Social' é obrigatório!")]
        public string LegalName { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo 'Nome Fantasia' é obrigatório!")]
        public string TradeName { get; set; } = string.Empty;
        [CNPJ(ErrorMessage = "O Campo 'CNPJ' é inválido!")]
        [Required(ErrorMessage = "O campo 'CNPJ' é obrigatório!")]
        public string TaxId { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo 'CEP' é obrigatório!")]
        public string PostalCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo 'Estado' é obrigatório!")]
        public string State { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo 'Cidade' é obrigatório!")]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo 'Bairro' é obrigatório!")]
        public string Neighborhood { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo 'Endereço' é obrigatório!")]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo 'Complemento' é obrigatório!")]
        public string Complement { get; set; } = string.Empty;   
        public DateTimeOffset CreateDate { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
    }
}
