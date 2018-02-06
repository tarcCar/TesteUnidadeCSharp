using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    public class Avaliador
    {
        private double maiorDeTodos = Double.MinValue;
        private double menorDeTodos = Double.MaxValue;
        private double media = 0;
        private List<Lance> maiores = new List<Lance>();
        public void Avalia(Leilao leilao)
        {
            if (leilao.Lances.Count == 0)
                throw new Exception("Não é possivel avaliar sem lances");

            foreach (Lance lance in leilao.Lances)
            {
                if (lance.Valor > maiorDeTodos)
                {
                    maiorDeTodos = lance.Valor;
                }
                if (lance.Valor < menorDeTodos)
                {
                    menorDeTodos = lance.Valor;
                }
                media += lance.Valor;
            }
            media = media / leilao.Lances.Count;
            ListaOsTresMaiores(leilao);

        }

        private void ListaOsTresMaiores(Leilao leilao)
        {
            maiores = new List<Lance>(leilao.Lances.OrderByDescending(l => l.Valor));
            int range = (maiores.Count > 3 ? 3 : maiores.Count);
            maiores = maiores.GetRange(0, range);
        }

        public double MaiorLance { get { return maiorDeTodos; } }
        public double MenorLance { get { return menorDeTodos; } }
        public double Media { get { return media; } }
        public List<Lance> Maiores { get { return maiores; } }
    }
}
