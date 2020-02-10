using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA.LambdaExpressions;

namespace ProgramacionAvanzada.Test
{
    [TestClass]
    public class Test_EvTest_Lambdaents
    {
        [TestMethod]
        public void TestMethod1()
        {
            EjemploLambda ejemploLambda = new EjemploLambda();
            var result = ejemploLambda.TestLambda();
            Assert.AreEqual(2, result);
        }
    }
}
