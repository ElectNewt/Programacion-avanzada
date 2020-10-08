using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA.Yield
{
    public class Coche
    {
        public readonly MarcaCoche Marca;
        public readonly string Modelo;

        public Coche(MarcaCoche marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
        }
    }


    public enum MarcaCoche
    {
        Opel,
        Audi
    }
}
