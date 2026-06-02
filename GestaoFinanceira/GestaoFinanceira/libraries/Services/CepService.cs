using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Domain.Libraries.Services
{
    internal class Cepservice : ICepservice
    {

        public async Task<LocalAddress?> SearchByPostalCode(string potalCode)
        {
            var url = $"https://viacep.com.br/ws/{potalCode.Replace(".", string.Empty).Replace("-", string.Empty)}/json/";

            var http = new HttpClient();
            return await http.GetFromJsonAsync<LocalAddress>(url);
        }
    }
    public class LocalAddress
    {
        public string Cep { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Complemento { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Localidade { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Regiao { get; set; } = string.Empty;
        public string IBGE { get; set; } = string.Empty;
        public string GIA { get; set; } = string.Empty;
        public string DDD { get; set; } = string.Empty;
        public string siafi { get; set; } = string.Empty;
    }
}
