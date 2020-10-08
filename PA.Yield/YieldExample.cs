using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Yield
{
    public class YieldExample
    {
        public void Ejemplo()
        {
            List<Coche> coches = new List<Coche>()
            {
                new Coche(MarcaCoche.Audi, "A3"),
                new Coche(MarcaCoche.Audi, "A5"),
                new Coche(MarcaCoche.Opel, "Vectra"),
                new Coche(MarcaCoche.Opel, "Astra"),
            };


            foreach (string modelo in FiltrarCochesGetNombresYield(coches))
            {
                Console.WriteLine($"El modelo del cohce es {modelo}");
            }

        }

        public IEnumerable<string> FiltrarCochesGetNombresYield(List<Coche> coches)
        {
            foreach (Coche coche in coches)
            {
                if (coche.Marca == MarcaCoche.Opel)
                {
                    yield return coche.Modelo;
                }
            }
        }


    }
}
