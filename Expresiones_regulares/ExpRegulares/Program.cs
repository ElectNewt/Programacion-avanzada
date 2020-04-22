using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace ExpRegulares
{
    class Program
    {
        static void Main(string[] args)
        {
            string frase = "Frase numero 01 en el blog de netmentor.es para explicar las expresiones regulares, repeticion de caracteres y 01 numeros01.";
            
            bool isMatch = Regex.IsMatch(frase, @"NetMentor\.es", RegexOptions.Compiled);


            Match resultadoMatch = Regex.Match(frase, @"netmentor\.es");


            MatchCollection matches = Regex.Matches(frase, "\\d{2}");

            string fraseCambidad = Regex.Replace(frase, "las expresiones regulares", "regex");


            string[] arrayfrases = Regex.Split(frase, ",");



            Console.WriteLine("Hello World!");
        }
    }
}
