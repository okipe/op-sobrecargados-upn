using System;

namespace EjemploSobrecargaOperadoresUnarios
{
    public class Numero
    {
        public int Valor { get; set; }

        // Sobrecarga del operador unario ++ para incrementar en 1 el valor de la propiedad Valor de un objeto Numero
        public static Numero operator ++(Numero num)
        {
            num.Valor++;
            return num;
        }

        // Sobrecarga del operador unario -- para decrementar en 1 el valor de la propiedad Valor de un objeto Numero
        public static Numero operator --(Numero num)
        {
            num.Valor--;
            return num;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Se crea un objeto Numero con valor inicial 5 para su propiedad Valor
            Numero num = new Numero { Valor = 5 };

            // Se utiliza la sobrecarga del operador ++ para incrementar en 1 el valor de la propiedad Valor del objeto num
            num++;
            Console.WriteLine($"Valor después de ++: {num.Valor}");

            // Se utiliza la sobrecarga del operador -- para decrementar en 1 el valor de la propiedad Valor del objeto num
            num--;
            Console.WriteLine($"Valor después de --: {num.Valor}"); 
        }
    }
}

/* CONSOLE ******************************
Valor después de ++: 6
Valor después de --: 5
****************************************/



/* CURIOSIDAD ****************************

// Si pongo...
public int Valor { get; set; }
    public static Numero operator ++(Numero num)
    {
        num.Valor--;
        return num;
    }

    public static Numero operator --(Numero num)
    {
        num.Valor++;
        return num;
    }

// Me sale
Valor después de ++: 4
Valor después de --: 5
 
 ***************************************/