/* INSTRUCCIONES *****************************
Diseña un programa en C# que aplique la sobrecarga de operadores creando una clase «Fraccion», que represente a una fracción, formada por un numerador y un denominador. Crea un constructor que reciba ambos datos como parámetros y otro constructor que reciba solo el numerador. Imprime la fracción de la forma a/b. Redefine los operadores "+", "-", "*" y "/" para que permitan realizar las operaciones habituales con fracciones.
 *******************************************/

namespace Caso1Mio
{
    public class Fraccion
    {
        public int Numerador { get; set; }
        public int Denominador { get; set; }

        // Sobrecarga de binarios suma para fracción
        public static Fraccion operator +(Fraccion f1, Fraccion f2)
        {
            return new Fraccion
            {
                Numerador = f1.Numerador * f2.Denominador + f2.Numerador * f1.Denominador,
                Denominador = f1.Denominador * f2.Denominador
            };
        }

        // Sobrecarga de binarios resta para fracción

        public static Fraccion operator -(Fraccion f1, Fraccion f2)
        {
            return new Fraccion
            {
                Numerador = f1.Numerador * f2.Denominador - f2.Numerador * f1.Denominador,
                Denominador = f1.Denominador * f2.Denominador
            };
        }

        /*class SobrecargaOperadoresUno
        {
            static void Main(string[] args)
            {
                Fraccion f1 = new Fraccion
                {
                    Console.WriteLine = "Ingrese numerador";
                    Numerador = Console.ReadLine()
                }
            }
        }*/

    }
}