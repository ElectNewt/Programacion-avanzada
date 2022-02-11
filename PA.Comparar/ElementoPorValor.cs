namespace PA.Comparar
{
    public struct ElementoPorValor 
    {
        public int Valor1 { get; set; }
        public int Valor2 {  get; set; }
      
        public static bool operator ==(ElementoPorValor c1, ElementoPorValor c2) 
        {
            return c1.Equals(c2);
        }
        
        public static bool operator !=(ElementoPorValor c1, ElementoPorValor c2) 
        {
            return !c1.Equals(c2);
        }
    }
}