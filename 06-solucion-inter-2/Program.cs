/*
Diseña un programa que aplique la sobrecarga de operadores a un número complejo, y crea una clase «Complejo»>, que represente a un número complejo (formado por una parte «real» y una parte «imaginaria», usando C#. Crea un método que permita sumar un complejo a otro, y redefine el operador "+", así como la resta de un complejo y muestra el resultado.
 */

using System;
namespace _06_solucion_inter_2
{
    public class Complejo
    {
        // Variables privadas para almacenar las partes real e imaginaria del número complejo
        private double real;
        private double imaginaria;

        // Constructor de la clase Complejo
        public Complejo(double re, double im)
        {
            // Inicializa las partes real e imaginaria del número complejo con los valores pasados como argumentos
            real = re;
            imaginaria = im;
        }

        // Asignación de complejos. Método para asignar nuevos valores a las partes real e imaginaria del número complejo
        public void AsignarComplejos(double re, double im)
        {
            real = re;
            imaginaria = im;
        }

        // Sobrecarga del operador + para la suma de complejos
        public static Complejo operator +(Complejo a, Complejo b)
        {
            return new Complejo(a.real + b.real, a.imaginaria + b.imaginaria);
        }

        // Sobrecarga del operador - para la diferencia de complejos
        public static Complejo operator -(Complejo a, Complejo b)
        {
            return new Complejo(a.real - b.real, a.imaginaria - b.imaginaria);
        }

        // Mostrar un número compejo. Sobrescribe el método ToString para mostrar el número complejo en forma de cadena
        public override string ToString()
        {
            // Devuelve una cadena con el formato "real + imaginaria", donde "real" es la parte real del número complejo y "imaginaria" es la parte imaginaria seguida de la letra "i"
            return (String.Format("{0}" + (imaginaria >= 0 ? "+" : " ") + "{1}i", real, imaginaria));
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // Crea varios objetos de la clase Complejo
            Complejo a = new Complejo(1.2, 1);
            Complejo b;
            Complejo c = new Complejo(1.5, 1);
            Complejo d;

            double real, imaginario;
            Console.WriteLine("Número complejo: ");
            Console.WriteLine("Real: ");
            real = double.Parse(Console.ReadLine());
            Console.WriteLine("Imaginario:");
            imaginario = double.Parse(Console.ReadLine());

            // Asigna el número complejo ingresado por el usuario al objeto a utilizando el método AsignarComplejos
            a.AsignarComplejos(real, imaginario);
            b = a;
            d = a + b + c;
            d = d + new Complejo(5, 2);

            // Muestra el resultado en la consola utilizando el método ToString sobrescrito en la clase Complejo
            Console.WriteLine(d.ToString());
        }
    }
}

/* CONSOLE ***********
 Suma: A = 4, B = 6
Resta: A = -4, B = -3
*********************/ 

/* COMENTARIOS ************************************************
Este programa define una clase Complejo que representa un número complejo formado por una parte real y una parte imaginaria. La clase define un constructor que toma dos argumentos re e im para inicializar las partes real e imaginaria del número complejo. También se define un método AsignarComplejos que permite asignar nuevos valores a las partes real e imaginaria del número complejo.

La clase también sobrecarga los operadores + y - para permitir la suma y resta de números complejos. El método ToString se sobrescribe para mostrar el número complejo en forma de cadena.

En el método Main, se crean varios objetos de la clase Complejo y se realizan operaciones de suma y resta con ellos. También se pide al usuario que ingrese un número complejo y se asigna a uno de los objetos utilizando el método AsignarComplejos. Finalmente, se muestra el resultado de las operaciones en la consola.
***************************************************************