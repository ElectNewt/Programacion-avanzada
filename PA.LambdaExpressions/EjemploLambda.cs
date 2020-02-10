using System;
using System.Collections.Generic;
using System.Linq;

namespace PA.LambdaExpressions
{

    public class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
    public class EjemploLambda
    {
        Func<int, bool> mayorDeEdad = edad => edad >= 18;

        public int TestLambda()
        {
            List<Persona> personas = new List<Persona>() {
                new Persona() { Edad = 14, Nombre = "Javier" },
                new Persona() { Edad = 18, Nombre = "Ivan" },
                 new Persona() { Edad = 25, Nombre = "Manuel" },
                new Persona() { Edad = 7, Nombre = "Lucas" }
            };

            List<Persona> mayoresDeEdad = personas.Where(a => a.Edad >= 18).ToList();

            return mayoresDeEdad.Count();
        }
    }
}
