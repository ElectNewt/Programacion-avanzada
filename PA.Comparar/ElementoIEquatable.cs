using System;

namespace PA.Comparar
{
    public class ElementoIEquatable : IEquatable<ElementoIEquatable>
    {
        public int Valor1 { get; set; }
        public int Valor2 {  get; set; }
        public DateTime Fecha { get; set; }

        public static bool operator ==(ElementoIEquatable c1, ElementoIEquatable c2) 
        {
            return c1.Equals(c2);
        }
        
        public static bool operator !=(ElementoIEquatable c1, ElementoIEquatable c2) 
        {
            return !c1.Equals(c2);
        }
        
        //Comparamos los objetos, pero sin tener en cuenta la fecha.
        public bool Equals(ElementoIEquatable other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Valor1 == other.Valor1 && Valor2 == other.Valor2;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ElementoIEquatable)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Valor1, Valor2);
        }
    }
}