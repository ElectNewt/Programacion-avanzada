using System;
using System.Collections.Generic;

namespace PA.Comparar
{
    public class ElementoIComparar : IComparer<ElementoIComparar>, IComparable<ElementoIComparar>
    {  
        public int Valor1 { get; set; }
        public int Valor2 {  get; set; }
        //ignoramos la fecha de la comparación
        public DateTime Fecha { get; set; }

        public ElementoIComparar(int valor1, int valor2, DateTime fecha)
        {
            Valor1 = valor1;
            Valor2 = valor2;
            Fecha = fecha;
        }


        public int Compare(ElementoIComparar x, ElementoIComparar y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            int valor1Comparison = x.Valor1.CompareTo(y.Valor1);
            if (valor1Comparison != 0) return valor1Comparison;
            return x.Valor2.CompareTo(y.Valor2);
        }

        public int CompareTo(ElementoIComparar other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            int valor1Comparison = Valor1.CompareTo(other.Valor1);
            if (valor1Comparison != 0) return valor1Comparison;
            return Valor2.CompareTo(other.Valor2);
        }
    }
}