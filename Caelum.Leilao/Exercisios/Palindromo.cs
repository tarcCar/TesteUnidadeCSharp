using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Exercisios
{
    public class Palindromo
    {
        public bool EhPalindromo(String frase)
        {
            String fraseFiltrada = frase
                    .ToUpper().Replace(" ", "").Replace("-", "");

            for (int i = 0; i < fraseFiltrada.Length; i++)
            {
                var index = i == 0 ? 1 : i+1;
                if (fraseFiltrada[i] != fraseFiltrada[fraseFiltrada.Length - index])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
