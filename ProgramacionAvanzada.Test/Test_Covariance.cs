using Microsoft.VisualStudio.TestTools.UnitTesting;
using PA.Covariance;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramacionAvanzada.Test
{

    [TestClass]
    public class Test_Covariance
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Persona> personas = new List<Persona>()
            {
                new Becario(),
                new Jefe()
            };

            Ejemplo.Imprimir(personas);

        }

        [TestMethod]
        public void TestMethod2()
        {
            List<Jefe> jefe = new List<Jefe>()
            {
                new Jefe(),
                new Jefe()
            };

            Ejemplo.Imprimir(jefe);

        }

        [TestMethod]
        public void testmethod3()
        {
            var accionBecario = new Action<Becario>(a => Console.WriteLine("Preparar el café"));
            Ejemplo.RealizarAccionBecario(accionBecario);


            var accionJEfe = new Action<Jefe>(a => Console.WriteLine("Preparar un meeting"));
            Ejemplo.RealizarAccionBecario(accionJEfe);

            var accionEmpleado = new Action<Empleado>(a => Console.WriteLine("trabaja"));
            Ejemplo.RealizarAccionBecario(accionEmpleado);

        }

    }
}
