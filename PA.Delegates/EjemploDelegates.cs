using System;

namespace PA.Delegates
{

    public delegate void Imprimir<T>(T valor);

    public class EjemploDelegates
    {

        public void ImprimirPantalla(string v)
        {
            Console.WriteLine(v);
        }
        public void ImprimirPantalla(int v)
        {
            Console.WriteLine($"el valor es {v}");
        }

        public void EjemploDelegado()
        {
            Imprimir<string> imprimirDel = new Imprimir<string>(ImprimirPantalla);
            

            imprimirDel("TExto a imprimir");

            Imprimir<int> imprimirDelEntero = new Imprimir<int>(ImprimirPantalla);
            imprimirDelEntero(5);

        }


        public void EjemploAction()
        {
            Action<string> actionEjemplo = ImprimirPantalla;
        }


        public void EjemploMetodoAnonimo()
        {
            Action<string> actionEjemploAnonimo = delegate (string valor)
            {
                Console.WriteLine(valor);
            };

            actionEjemploAnonimo("valor a imprimir");

            Action<string> actionEjemploAnonimoLambada = v => Console.WriteLine(v);

            actionEjemploAnonimoLambada("valor a imprimir");
        }
        

        public void EjemploFunc()
        {
            Func<int, string> delegadoFunc1 = v => $"el valor es {v}";
            Console.WriteLine(delegadoFunc1(23));
        }

        public void EjemploFunc2()
        {
            Func<int, int, int> delegadoFunc2 = (v, x) => v * x;
            int resultado = delegadoFunc2(3, 4);

            Console.WriteLine($"el valor es{resultado}");
        }

        public void EjemploPRedicate()
        {
            Predicate<int> mayorDeEdad = v => v >= 18;
            bool isMayorDeEdad = mayorDeEdad(25);

            Console.WriteLine(isMayorDeEdad ? "es mayor de edad" : "no es mayor de edad");


        }





    }



}
