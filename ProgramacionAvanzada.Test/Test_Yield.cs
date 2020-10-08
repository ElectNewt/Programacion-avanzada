using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA.Yield;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramacionAvanzada.Test
{
    [TestClass]
    public class Test_Yield
    {
        [TestMethod]
        public void TestMethod1()
        {
            YieldExample ejemploYield = new YieldExample();
            ejemploYield.Ejemplo();
            Assert.IsTrue(true);
        }
    }
}
