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
    public class PalindromoTest
    {
        [Test]
        public void TestarPalindromo()
        {
            
            string frase = "Socorram-me subi no onibus em Marrocos";
            bool resultado = false;

             resultado = new Palindromo().EhPalindromo(frase);
            bool esperado = true;

            Assert.AreEqual(esperado, resultado);
            

        }
    }
}
