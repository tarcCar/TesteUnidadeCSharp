using Caelum.Leilao.Exercisios;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Test.Exercisios
{
    [TestFixture]
    public class AnoBissextoTest
    {
        [Test]
        public void TestaSeAnoBissexto()
        {
            AnoBissexto anoBissexto = new AnoBissexto();

            var ehBissexto = anoBissexto.ehBissexto(2016);
            Assert.IsTrue(ehBissexto);
        }
        [Test]
        public void TestaSeNaoEhAnoBissexto()
        {
            AnoBissexto anoBissexto = new AnoBissexto();

            var naoEhBissexto = anoBissexto.ehBissexto(2001);
            Assert.IsFalse(naoEhBissexto);
        }
    }
}
