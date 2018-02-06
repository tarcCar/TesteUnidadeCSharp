using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caelum.Leilao.Test
{
    [TestFixture]
    public class LanceTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void NaoDeveAceitarLanceComValorZero()
        {
            new Lance(new Usuario("Jose"), 0);
        }
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void NaoDeveAceitarLanceComValorNegativo()
        {
            new Lance(new Usuario("Jose"), -20);
        }
    }
}
