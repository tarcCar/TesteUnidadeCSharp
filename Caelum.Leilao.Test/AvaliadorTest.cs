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
            Assert.AreEqual(menorEsperado, leiloeiro.MenorLance);

        }
        [Test]
        public void DeveEntenderLancesEmOrdemDecrescente()
        {
            // cenario: 
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(jose, 400.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(maria, 250.0));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
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
            // cenario:
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");
            Usuario maria = new Usuario("Maria");
            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 200));
            leilao.Propoe(new Lance(joao, 450));
            leilao.Propoe(new Lance(jose, 120));

            leilao.Propoe(new Lance(maria, 700));
            leilao.Propoe(new Lance(joao, 630));
            leilao.Propoe(new Lance(jose, 230));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
           
            Assert.AreEqual(700, leiloeiro.MaiorLance);
            Assert.AreEqual(120, leiloeiro.MenorLance);

        }
        [Test]
        public void TestarCalculoMedia()
        {
            // cenario: 
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
        [Test]
        public void TestarComUmLance()
        {
            // cenario: 
            Usuario joao = new Usuario("Joao");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 3000.0));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado

            Assert.AreEqual(3000, leiloeiro.MaiorLance, 0.00001);
            Assert.AreEqual(3000, leiloeiro.MenorLance, 0.00001);
        }
        [Test]
        public void TestaOsMaioresComVariosLances()
        {
            // cenario: 
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");
            Usuario cleiton = new Usuario("cleiton");
            Usuario rodolfo = new Usuario("rodolfo");
            Usuario josicley = new Usuario("josicley");
            Usuario maria = new Usuario("Maria");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(maria, 250.0));
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));
            leilao.Propoe(new Lance(cleiton, 600.0));
            leilao.Propoe(new Lance(rodolfo, 900.0));
            leilao.Propoe(new Lance(josicley, 1000.0));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
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
            // cenario: 
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("José");

            Leilao leilao = new Leilao("Playstation 3 Novo");

            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            var maiores = leiloeiro.Maiores;
            Assert.AreEqual(2, maiores.Count);
            Assert.AreEqual(maiores[0].Valor, 400, 0.00001);
            Assert.AreEqual(maiores[1].Valor, 300, 0.00001);

        }
        [Test]
        public void TestaOsMaioresComNenhumLance()
        {
            // cenario: 

            Leilao leilao = new Leilao("Playstation 3 Novo");


            // executando a acao
            Avaliador leiloeiro = new Avaliador();
            leiloeiro.Avalia(leilao);

            // comparando a saida com o esperado
            var maiores = leiloeiro.Maiores;
            Assert.AreEqual(0, maiores.Count);

        }
    }
}
