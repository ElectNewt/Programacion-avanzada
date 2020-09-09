using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using PA.EjIDisposable;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProgramacionAvanzada.Test
{
    [TestClass]
    public class Test_IDisposable
    {
        [TestMethod]
        public void EjemploUsing()
        {

            using (EjemploClaseDisposable ej = new EjemploClaseDisposable())
            {
                ej.Metodo1Ejemplo();
            }
        }

        [TestMethod]
        public void EjemploInstanciar()
        {
            EjemploClaseDisposable ej = new EjemploClaseDisposable();
            ej.Metodo1Ejemplo();
            ej.Dispose();
        }


        [TestMethod]
        public void EjemploejecutarDb()
        {
            var wrapper = new DatabaseWrapper();
            var fecha = wrapper.GetFecha();
            Console.WriteLine(fecha);
            Assert.IsTrue(true);
        }


        [TestMethod]
        public void EjemploEjecutarDbNoDisposable()
        {
            for (int i = 0; i < 1000; i++)
            {
                var wrapper = new DatabaseWrapper();
                var fecha = wrapper.GetFecha();
                Console.WriteLine(fecha);
            }
            Assert.IsTrue(true);
        }


        [TestMethod]
        public void EjemploLeerDisposed()
        {
            for (int i = 0; i < 1000; i++)
            {
                using (var wrapper = new DatabaseWrapperDispose())
                {
                    var fecha = wrapper.GetFecha();
                    Console.WriteLine(fecha);
                }
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EjemploLeerDisposedTryFinally()
        {
            for (int i = 0; i < 1000; i++)
            {
                DatabaseWrapperDispose wrapper = null;
                try
                {
                    wrapper = new DatabaseWrapperDispose();
                    var fecha = wrapper.GetFecha();
                }
                finally
                {
                    wrapper.Dispose();
                }
            }
            Assert.IsTrue(true);
        }
    }
}
