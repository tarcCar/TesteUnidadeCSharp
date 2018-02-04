using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Exercisios
{
    public class AnoBissexto
    {
        public bool ehBissexto(int ano)
        {
            if ((ano % 400) == 0) return true;
            else if ((ano % 100) == 0) return true;
            else if ((ano % 4) == 0) return true;
            else return false;
        }
    }
}
