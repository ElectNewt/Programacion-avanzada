using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA.Events;

namespace ProgramacionAvanzada.Test
{
    [TestClass]
    public class Test_Events
    {
        [TestMethod]
        public void TestMethod1()
        {
            SuscriptorCalculadoraVirtual calculadoraVirutal = new SuscriptorCalculadoraVirtual(3, 2);
            calculadoraVirutal.OperacionSuma();
            calculadoraVirutal.OperacionResta();

        }
    }
}
