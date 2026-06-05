using GestaoFinanceira.Domain;
using System.ComponentModel.DataAnnotations;
using Gestao.Domain.Libraries.Validations;
using Gestao.Domain.Interfaces;

namespace Gestao.Domain
{
    public class Company : ISoftDelete
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Razão Social' é obrigatório!")]
        [MinLength(3, ErrorMessage = "O Campo 'Razão Social' deve ter pelo menos {1} caracteres!")]
        public string LegalName { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo 'Nome Fantasia' é obrigatório!")]
        [MinLength(3, ErrorMessage = "O Campo 'Nome Fantasia' deve ter pelo menos {1} caracteres!")]
        public string TradeName { get; set; } = string.Empty;

        [CNPJ(ErrorMessage = "O Campo 'CNPJ' é inválido!")]
        [Required(ErrorMessage = "O campo 'CNPJ' é obrigatório!")]
        public string TaxId { get; set; } = string.Empty;

        [MinLength(10, ErrorMessage = "O Campo 'CEP' deve ter {1} caracteres!")]
        [Required(ErrorMessage = "O campo 'CEP' é obrigatório!")]
        public string PostalCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo 'Estado' é obrigatório!")]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo 'Cidade' é obrigatório!")]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo 'Bairro' é obrigatório!")]
        public string Neighborhood { get; set; } = string.Empty;

        [MinLength(10, ErrorMessage = "O Campo 'Endereço' deve ter pelo menos {1} caracteres!")]
        [Required(ErrorMessage = "O campo 'Endereço' é obrigatório!")]
        public string Address { get; set; } = string.Empty;

        [MinLength(3, ErrorMessage = "O Campo 'Complemento' deve ter pelo menos {1} caracteres!")]
        [Required(ErrorMessage = "O campo 'Complemento' é obrigatório!")]
        public string Complement { get; set; } = string.Empty;   

        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
       
    }
}
