using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using PA.Comparar;

namespace ProgramacionAvanzada.Test
{

    [TestClass]
    public class Test_Comparar
    {
        [TestMethod]
        public void TestOperatorValueTypes()
        {
            int value1 = 1;
            int value2 = 1;

            bool sonIguales = value1 == value2; //true
            
            Assert.IsTrue(sonIguales);
        }
        
        
        [TestMethod]
        public void TestOperatorCustomValueType()
        {
            ElementoPorValor elemento1 = new ElementoPorValor()
            {
                Valor1 = 1,
                Valor2 = 2
            };

            ElementoPorValor elemento2 = new ElementoPorValor()
            {
                Valor1 = 1,
                Valor2 = 2
            };

            bool sonIguales = elemento1 == elemento2; //true
            bool sonIgualesOpt2 = elemento1.Equals(elemento2);//true
            
            Assert.IsTrue(sonIguales);
            Assert.IsTrue(sonIgualesOpt2);
        }

        [TestMethod]
        public void TestOperatorReferenceTypes()
        {
            ElementoReferencia elemento1 = new ElementoReferencia()
            {
                Valor1 = 1,
                Valor2 = 2
            };
            ElementoReferencia elemento2 = new ElementoReferencia()
            {
                Valor1 = 1,
                Valor2 = 2
            };
            
            ElementoReferencia elemento1Copia = elemento1;

            bool dosPrimeros = elemento1 == elemento2; 
            bool laCopia = elemento1 == elemento1Copia; 
           
            Assert.IsTrue(dosPrimeros);
            Assert.IsTrue(laCopia);
            
            bool dosPrimeros2 = elemento1.Equals(elemento2); 
            bool laCopia2 = elemento1.Equals(elemento1Copia);
            
            Assert.IsFalse(dosPrimeros2);
            Assert.IsTrue(laCopia2);
        }
        
        [TestMethod]
        public void TestElementoIEquatable()
        {
            
            ElementoIEquatable elemento1 = new ElementoIEquatable()
            {
                Valor1 = 1,
                Valor2 = 2
            };
            ElementoIEquatable elemento2 = new ElementoIEquatable()
            {
                Valor1 = 1,
                Valor2 = 2
            };
            
            ElementoIEquatable elemento1Copia = elemento1;

            bool dosPrimeros = elemento1 == elemento2; 
            bool laCopia = elemento1 == elemento1Copia;
           
            Assert.IsTrue(dosPrimeros);
            Assert.IsTrue(laCopia);
        }
        
        [TestMethod]
        public void TestElementoIComparable()
        {

            ElementoIComparar elemento1 = new ElementoIComparar(1, 2, DateTime.UtcNow);
            ElementoIComparar elemento2 = new ElementoIComparar(2, 2, DateTime.UtcNow); 
            ElementoIComparar elemento3 = new ElementoIComparar(1, 2, DateTime.UtcNow);


            List<ElementoIComparar>listaComparar = new List<ElementoIComparar>()
            {
                elemento1, elemento2, elemento3
            };

            List<ElementoIComparar> listaOrdenada = listaComparar.OrderBy(x => x).ToList();
            
            // elemento2 es el último al tener el primer valor con un 2
            Assert.AreEqual(elemento2, listaOrdenada.Last());
        }
        
        
    }
}
