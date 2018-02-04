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
    public class MatematicaMalucaTest
    {
        [Test]
        public void TestaCasoMaiorQueTrinta()
        {
            MatematicaMaluca matematica = new MatematicaMaluca();
            var valor = matematica.ContaMaluca(60);
            Assert.AreEqual(240, valor, 0.00001);
        }
        [Test]
        public void TestaCasoMaiorQueDez()
        {
            MatematicaMaluca matematica = new MatematicaMaluca();
            var valor = matematica.ContaMaluca(15);
            Assert.AreEqual(45, valor, 0.00001);
        }
        [Test]
        public void TestaCasoRestante()
        {
            MatematicaMaluca matematica = new MatematicaMaluca();
            var valor = matematica.ContaMaluca(2);
            Assert.AreEqual(4, valor, 0.00001);
        }
    }
}
