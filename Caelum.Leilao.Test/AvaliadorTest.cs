using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao
{
    [TestFixture]
    public class TesteAvaliador
    {
        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            // cenario: 3 lances em ordem crescente
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            double maiorEsperado = 400;
            double menorEsperado = 250;
            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado , leiloeiro.MenorLance);

        }
        [Test]
        public void TestarCalculoMedia()
        {
            // cenario: 3 lances em ordem crescente
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            double mediaEsperada = 316.66;
            Assert.AreEqual(mediaEsperada, leiloeiro.Media, 0.01);
        }
    }
}
