namespace PA.Comparar
{
    public class ElementoReferencia 
    {
        public int Valor1 { get; set; }
        public int Valor2 {  get; set; }
        
        public static bool operator ==(ElementoReferencia c1, ElementoReferencia c2)
        {
            return c1.Valor1 == c2.Valor1 && c1.Valor2 == c2.Valor2;
        }
        
        public static bool operator !=(ElementoReferencia c1, ElementoReferencia c2)
        {
            return c1.Valor1 != c2.Valor1 || c1.Valor2 != c2.Valor2;
        }
    }
}