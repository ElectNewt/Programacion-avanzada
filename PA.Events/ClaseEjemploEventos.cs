using System;

namespace PA.Events
{
    public class EditorCalculadora
    {
        public delegate void EjemploDelegado();
        public event EjemploDelegado ejemploEvento;

        public void Sumar(int a, int b)
        {
            if(ejemploEvento != null)
            {
                ejemploEvento();
                Console.WriteLine($"la suma es {a + b}");
            }
            else
            {
                Console.WriteLine($"No estas suscrito a los eventos.");

            }

        }

        public void Resta(int a, int b)
        {
            if (ejemploEvento != null)
            {
                ejemploEvento();
                Console.WriteLine($"la resta es {a - b}");
            }
            else
            {
                Console.WriteLine($"No estas suscrito a los eventos.");

            }

        }
    }

    public class SuscriptorCalculadoraVirtual
    {
        private EditorCalculadora editor;
        private int A;
        private int B;

        public void EjemploEventHandler()
        {
            Console.WriteLine("La operación va a ser ejecutada.");
        }
        public void EjemploEventHandler2()
        {
            Console.WriteLine("este es nuestro segundo evento.");
        }


        public SuscriptorCalculadoraVirtual(int a, int b)
        {
            editor = new EditorCalculadora();
            A = a;
            B = b;
            editor.ejemploEvento += EjemploEventHandler;
            editor.ejemploEvento += EjemploEventHandler2;

        }

        public void OperacionSuma()
        {
            editor.Sumar(A, B);
        }

        public void OperacionResta()
        {
            editor.Resta(A, B);
        }



    }
}
