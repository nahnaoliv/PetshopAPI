using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace PetshopAPI.Validacoes
{
    public class ValidarTelCelSimples
    {
        private static readonly Regex CelularRegex = new Regex(@"^\(?\d{2}\)?\s?9\d{4}-?\d{4}$");
        private static readonly Regex TelefoneFixoRegex = new Regex(@"^\(?\d{2}\)?\s?\d{4}-?\d{4}$");
        private static readonly string[] DDDsValidos = new string[] { "31", "32", "33", "34", "35", "37", "38", "21", "22", "24", "11","12","13" }; // Lista pré-definida de DDDs válidos

        public static bool Validar(string numero)
        {
            if (string.IsNullOrEmpty(numero))
            {
                return false;
            }

            numero = RemoverCaracteresEspeciais(numero);

            if (CelularRegex.IsMatch(numero))
            {
                return ValidarCelular(numero);
            }
            else if (TelefoneFixoRegex.IsMatch(numero))
            {
                return ValidarTelefoneFixo(numero);
            }
            else
            {
                return false;
            }
        }

        private static bool ValidarCelular(string numero)
        {
            string ddd = numero.Substring(0, 2);
            return DDDsValidos.Contains(ddd);
        }

        private static bool ValidarTelefoneFixo(string numero)
        {
            // Implementar validação de telefone fixo (opcional)

            return true; // Remover ou implementar validação de telefone fixo
        }

        private static string RemoverCaracteresEspeciais(string numero)
        {
            return Regex.Replace(numero, "[^0-9]", "");
        }
    }
}
