
namespace Gestao.Domain.Libraries.Services
{
    internal interface ICepservice
    {
        Task<LocalAddress?> SearchByPostalCode(string potalCode);
    }
}