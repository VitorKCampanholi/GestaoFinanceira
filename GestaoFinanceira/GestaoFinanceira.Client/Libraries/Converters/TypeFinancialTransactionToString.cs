using Gestao.Domain.Enums;

namespace GestaoFinanceira.Client.Libraries.Converters
{
    public class TypeFinancialTransactionToString
    {
        public static string Converter(string type)
        {
            return type == TypeFinancialTransction.Pay.ToString() ? "Pagamento" : "Recebimento";
        }

        public static string ConverterInfinitive(string type)
        {
            return type == TypeFinancialTransction.Pay.ToString() ? "Pagar" : "Receber";
        }
    }
}
