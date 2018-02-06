using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Test.Builder
{
    public class LeilaoBuilder
    {
        private Leilao leilao;

        public LeilaoBuilder Para(string descricao)
        {
           leilao =  new Leilao(descricao);
           return this;
        }
        public LeilaoBuilder Lance(Usuario usuario,Double valor)
        {
            leilao.Propoe(new Lance(usuario, valor));
            return this;
        }
        public Leilao Constroi()
        {
            return leilao;
        }
    }
}
