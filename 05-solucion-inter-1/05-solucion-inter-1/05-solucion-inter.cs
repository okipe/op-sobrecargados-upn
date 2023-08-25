/* INSTRUCCIONES *****************************
Diseña un programa en C# que aplique la sobrecarga de operadores creando una clase «Fraccion», que represente a una fracción, formada por un numerador y un denominador. Crea un constructor que reciba ambos datos como parámetros y otro constructor que reciba solo el numerador. Imprime la fracción de la forma a/b. Redefine los operadores "+", "-", "*" y "/" para que permitan realizar las operaciones habituales con fracciones.
 *******************************************/

using System;

public class Fraccion
{
    // Campos privados de solo lectura para almacenar el numerador y el denominador de la fracción
    private readonly int num;
    private readonly int den;

    // Constructor que recibe el numerador y el denominador como parámetros
    public Fraccion(int numerador, int denominador)
    {
        // Si el denominador es cero, se lanza una excepción
        if (denominador == 0)
        {
            throw new ArgumentException("El denominador no puede ser cero.",
                nameof(denominador));
        }

        // Se asignan los valores de los parámetros a los campos num y den
        num = numerador;
        den = denominador;
    }

    // Métodos para ingresar el numerador y denominador desde la consola
    public int IngresarNumerador()
    {
        Console.Write("Ingrese numerador: ");
        int num = int.Parse(Console.ReadLine());
        return num;
    }
    public int IngresarDenominador() 
    {
        Console.Write("Ingrese denominador: ");
        int den =  int.Parse(Console.ReadLine());
        Console.WriteLine();
        return den;
    }

    // Sobrecarga de operadores unarios para las operaciones
    public static Fraccion operator +(Fraccion m) => m;
    public static Fraccion operator -(Fraccion m) => new Fraccion(-m.num, m.den);

    // Sobrecarga de operadores binarios según operaciones solicitadas
    public static Fraccion operator +(Fraccion m, Fraccion n) => new Fraccion(m.num * n.den + n.num * m.den, m.den * n.den);
    public static Fraccion operator -(Fraccion m, Fraccion n) => m + (-n);
    public static Fraccion operator *(Fraccion m, Fraccion n) => new Fraccion(m.num * n.num, m.den * n.den);
    public static Fraccion operator /(Fraccion m, Fraccion n)
    {
        // Si el numerador del objeto n es cero, se lanza una excepción de división por cero
        if(n.num == 0)
        {
            throw new DivideByZeroException();
        }
        return new Fraccion(m.num * n.den, m.den * n.num);
    }
    // Sobrescritura del método ToString para devolver una representación en cadena de la fracción en forma a/b
    public override string ToString() => $"{num} / {den}";
}

public static class OperatorOverloading
{
    public static void Main()
    {
        // Se crea un objeto Fraccion f con valores iniciales 2 y 3 para sus campos num y den
        Fraccion f = new Fraccion(2,3);

        // Se ingresa valores y luego se crea un objeto fracción
        int num = f.IngresarNumerador();
        int den = f.IngresarDenominador();
        var a = new Fraccion(num, den); // 5/4

        num = f.IngresarNumerador(); 
        den = f.IngresarDenominador();
        var b = new Fraccion(num, den); // 1/2

        Console.WriteLine($"Fracción 1 negativa: {-a}"); // output -5/4
        Console.WriteLine($"Suma: {a + b}"); // output 14/8
        Console.WriteLine($"Resta: {a - b}"); // output 6/8
        Console.WriteLine($"Multiplicación: {a * b}"); // output 5/8
        Console.WriteLine($"División: {a/ b}"); // output 10/4
    }
}