using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Test
{
    [TestFixture]
    public class LeilaoTest
    {
        [Test]
        public void TestePropoeUmItem()
        {
            // cenario: 
            Usuario joao = new Usuario("Joao");
            Leilao leilao = new Leilao("Playstation 3 Novo");
            Assert.AreEqual(0, leilao.Lances.Count);
            leilao.Propoe(new Lance(joao, 300.0));
            // comparando a saida com o esperado
            Assert.AreEqual(1, leilao.Lances.Count);

        }
        [Test]
        public void TestePropoeVariosItens()
        {
            // cenario: 
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");
            Leilao leilao = new Leilao("Playstation 3 Novo");
            Assert.AreEqual(0, leilao.Lances.Count);
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 1000.0));
            // comparando a saida com o esperado
            Assert.AreEqual(2, leilao.Lances.Count);
            Assert.AreEqual(300,leilao.Lances[0].Valor,0.00001);
            Assert.AreEqual(1000, leilao.Lances[1].Valor,0.00001);
        }
        [Test]
        public void NaoPodeAceitarLanceDoMesmoUsuarioEmSequencia()
        {
            // cenario: 
            Usuario joao = new Usuario("Joao");
            Leilao leilao = new Leilao("Playstation 3 Novo");
            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(joao, 300.0));
            // comparando a saida com o esperado
            Assert.AreEqual(1, leilao.Lances.Count);
        }

        [Test]
        public void UsuarioSoPodeProporCincoPropostas()
        {
            // cenario: 
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("Jose");

            Leilao leilao = new Leilao("Playstation 3 Novo");

           

            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(jose, 200.0));

            leilao.Propoe(new Lance(joao, 300.0));
            leilao.Propoe(new Lance(jose, 400.0));

            leilao.Propoe(new Lance(joao, 500.0));
            leilao.Propoe(new Lance(jose, 600.0));

            leilao.Propoe(new Lance(joao, 700.0));
            leilao.Propoe(new Lance(jose, 800.0));

            leilao.Propoe(new Lance(joao, 900.0));
            leilao.Propoe(new Lance(jose, 1000.0));

            Assert.AreEqual(10, leilao.Lances.Count);

            leilao.Propoe(new Lance(joao, 1100.0));

            // comparando a saida com o esperado
            Assert.AreEqual(10, leilao.Lances.Count);
            int ultimoIndex = leilao.Lances.Count - 1;
            Assert.AreEqual(1000, leilao.Lances[ultimoIndex].Valor, 0.00001);

        }

        [Test]
        public void DeveDobrarOUltimoLanceDoUsuario()
        {
            // cenario: 
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("jose");
            Usuario cleyton = new Usuario("cleyton");

            Leilao leilao = new Leilao("Playstation 3 Novo");
            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(jose, 200.0));
            leilao.Propoe(new Lance(cleyton, 300.0));
            leilao.Propoe(new Lance(jose, 800.0));

            Assert.AreEqual(4, leilao.Lances.Count);

            leilao.DobraLance(cleyton);
            // comparando a saida com o esperado
            int ultimo = leilao.Lances.Count - 1;
            Assert.AreEqual(600, leilao.Lances[ultimo].Valor,0.00001);
        }
        [Test]
        public void NaoDeveAceitarDobrarLanceDeUsuariQueNaoFezLance()
        {
            // cenario: 
            Usuario joao = new Usuario("Joao");
            Usuario jose = new Usuario("jose");
            Usuario cleyton = new Usuario("cleyton");

            Leilao leilao = new Leilao("Playstation 3 Novo");
            leilao.Propoe(new Lance(joao, 100.0));
            leilao.Propoe(new Lance(jose, 200.0));
            leilao.Propoe(new Lance(joao, 800.0));

            Assert.AreEqual(3, leilao.Lances.Count);

            leilao.DobraLance(cleyton);
            // comparando a saida com o esperado
            int ultimo = leilao.Lances.Count - 1;
            Assert.AreEqual(800, leilao.Lances[ultimo].Valor, 0.00001);
        }
    }
}
