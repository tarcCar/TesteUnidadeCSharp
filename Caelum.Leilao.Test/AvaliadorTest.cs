using Caelum.Leilao.Test.Builder;
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
        private Avaliador leiloeiro;
        private Usuario joao;
        private Usuario jose;
        private Usuario cleiton;
        private Usuario rodolfo;
        private Usuario josicley;
        private Usuario maria;

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Executando Set up");
            leiloeiro = new Avaliador();
            joao = new Usuario("Joao");
            jose = new Usuario("José");
            cleiton = new Usuario("cleiton");
            rodolfo = new Usuario("rodolfo");
            josicley = new Usuario("josicley");
            maria = new Usuario("Maria");
        }
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Executando tear down");
        }
        [TestFixtureSetUp]
        public void TestandoBeforeClass()
        {
            Console.WriteLine("test fixture setup");
        }

        [TestFixtureTearDown]
        public void TestandoAfterClass()
        {
            Console.WriteLine("test fixture tear down");
        }
        [Test]
        public void DeveEntenderLancesEmOrdemCrescente()
        {
            // cenario: 3 lances em ordem crescente

            Leilao leilao = new LeilaoBuilder().Para("Playstation 3 Novo")
            .Lance(maria, 250.0)
            .Lance(joao, 300.0)
            .Lance(jose, 400.0)
            .Constroi();

            // executando a acao

            leiloeiro.Avalia(leilao);
            // comparando a saida com o esperado
            double maiorEsperado = 400;
            double menorEsperado = 250;
            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance);

        }
        [Test]
        public void DeveEntenderLancesEmOrdemDecrescente()
        {

            Leilao leilao = 
                new LeilaoBuilder().Para("Playstation 3 Novo")
                .Lance(jose, 400.0)
                .Lance(joao, 300.0)
                .Lance(maria, 250.0)
                .Constroi();
            

            // executando a acao

            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            double maiorEsperado = 400;
            double menorEsperado = 250;
            Assert.AreEqual(maiorEsperado, leiloeiro.MaiorLance);
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance);

        }
        [Test]
        public void DeveEntenderLancesEmOrdemRandomica()
        {

            Leilao leilao = new LeilaoBuilder().Para("Playstation 3 Novo")
               .Lance(maria, 200)
               .Lance(joao, 450)
               .Lance(jose, 120)
               .Lance(maria, 700)
               .Lance(joao, 630)
               .Lance(jose, 230)
               .Constroi();

            // executando a acao

            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado

            Assert.AreEqual(700, leiloeiro.MaiorLance);
            Assert.AreEqual(120, leiloeiro.MenorLance);

        }
        [Test]
        public void TestarCalculoMedia()
        {


            Leilao leilao = 
                new LeilaoBuilder().Para("Playstation 3 Novo")
                    .Lance(maria, 250.0)
                    .Lance(joao, 300.0)
                    .Lance(jose, 400.0)
                    .Constroi();
            // executando a acao

            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            double mediaEsperada = 316.66;
            Assert.AreEqual(mediaEsperada, leiloeiro.Media, 0.01);
        }
        [Test]
        public void TestarComUmLance()
        {

            Leilao leilao = new LeilaoBuilder().Para("Playstation 3 Novo")
             .Lance(joao, 3000.0)
             .Constroi();


            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado

            Assert.AreEqual(3000, leiloeiro.MaiorLance, 0.00001);
            Assert.AreEqual(3000, leiloeiro.MenorLance, 0.00001);
        }
        [Test]
        public void TestaOsMaioresComVariosLances()
        {
            Leilao leilao =
                new LeilaoBuilder().Para("Playstation 3 Novo")
                .Lance(maria, 250)
                .Lance(joao, 300)
                .Lance(jose, 400)
                .Lance(cleiton, 600)
                .Lance(rodolfo, 900)
                .Lance(josicley, 1000)
                .Constroi();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            var maiores = leiloeiro.Maiores;
            Assert.AreEqual(3, maiores.Count);
            Assert.AreEqual(maiores[0].Valor, 1000, 0.00001);
            Assert.AreEqual(maiores[1].Valor, 900, 0.00001);
            Assert.AreEqual(maiores[2].Valor, 600, 0.00001);
        }
        [Test]
        public void TestaOsMaioresComDoisLances()
        {
            Leilao leilao =
                new LeilaoBuilder().Para("Playstation 3 Novo")
                .Lance(joao, 300.0)
                .Lance(jose, 400.0)
                .Constroi();

            // executando a acao
            leiloeiro.Avalia(leilao);
            // comparando a saida com o esperado
            var maiores = leiloeiro.Maiores;
            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(maiores[0].Valor, 400, 0.00001);
            Assert.AreEqual(maiores[1].Valor, 300, 0.00001);
        }
        [Test]
        [ExpectedException(typeof(Exception))]
        public void TestaOsMaioresComNenhumLance()
        {
            // cenario: 
            Leilao leilao = new LeilaoBuilder().Para("Playstation 3 Novo").Constroi();
            // executando a acao
            leiloeiro.Avalia(leilao);

        }
    }
}
