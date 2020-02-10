using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA.Delegates;

namespace ProgramacionAvanzada.Test
{
    [TestClass]
    public class Test_Delegates
    {
        [TestMethod]
        public void TestMethod1()
        {
            EjemploDelegates del1 = new EjemploDelegates();
            del1.EjemploPRedicate();

        }
    }
}
