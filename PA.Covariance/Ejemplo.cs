using System;
using System.Collections.Generic;
using System.Text;

namespace PA.Covariance
{
    public class Ejemplo
    {

        public static void Imprimir(List<Persona> personas)
        {
            foreach(var persona in personas)
            {
                Console.WriteLine($"El elemento actual es de tipo {persona.GetType().ToString()}");
            }
        }

        public static void Imprimir(IEnumerable<Persona> personas)
        {
            foreach (var persona in personas)
            {
                Console.WriteLine($"El elemento actual es de tipo {persona.GetType().ToString()}");
            }
        }

        public static void RealizarAccionBecario(Action<Becario> accionBecario)
        {
            Becario b = new Becario();
            accionBecario(b);
        }

    }
}
