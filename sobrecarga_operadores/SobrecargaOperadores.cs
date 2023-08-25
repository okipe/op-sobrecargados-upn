/* COMENTARIO DEL EJEMPLO ************************************************
Ejemplo:
A continuación, se observa una clase con el nombre de coordenada, la cual tiene métodos, pero además está sobrecargando al operador +, ya que, si observamos la imagen, encontramos una función estática con el mismo nombre de la clase `Coordenada` con la palabra reservada `operator` y el operador +:
***************************************************************************/

using System;
using System.Threading;

namespace SobrecargaOperadores 
{
    public class Coordenada {
        // Propiedades A y B que representan las coordenadas del punto
        public double A { get; set; }
        public double B { get; set; }

        // Sobrecarga del operador + para sumar dos objetos Coordenada
        public static Coordenada operator + (Coordenada abscisa, Coordenada ordenada)
        {
            // Se crea un nuevo objeto Coordenada cuyas propiedades A y B son la suma de las propiedades A y B de los objetos abscisa y ordenada
            return new Coordenada { A = abscisa.A + ordenada.A, B = abscisa.B + ordenada.B}; 
        }

        // Sobrecarga del operador - para restar un entero a las propiedades A y B de un objeto Coordenada
        public static Coordenada operator - (Coordenada abscisa, int variable)
        {
            // Se crea un nuevo objeto Coordenada cuyas propiedades A y B son la resta de las propiedades A y B del objeto abscisa menos el entero variable
            return new Coordenada { A = abscisa.A - variable, B = abscisa.B - variable };
        }

        public Coordenada(){ }

        // Agregado por chat GPT
        class Program
        {
            static void Main(string[] args)
            {
                // Se crean dos objetos Coordenada c1 y c2 con valores iniciales para sus propiedades A y B
                Coordenada c1 = new Coordenada { A = 1.0, B = 2.0 };
                Coordenada c2 = new Coordenada { A = 3.0, B = 4.0 };

                // Se utiliza la sobrecarga del operador + para sumar y restar los objetos y se guarda el resultado en los objetos suma y resta
                Coordenada suma = c1 + c2;
                Coordenada resta = c1 - 5;

                Console.WriteLine($"Suma: A = {suma.A}, B = {suma.B}");
                Console.WriteLine($"Resta: A = {resta.A}, B = {resta.B}");
            }
        }
    }
}

/* ¿Qué es la sobrecarga de operadores? **********************************************

La sobrecarga de operadores es una característica de algunos lenguajes de programación, como C#, que permite a los programadores definir cómo se comportan los operadores predefinidos (como +, -, *, /, etc.) cuando se aplican a objetos de un tipo definido por el usuario¹. Esto significa que un tipo puede proporcionar una implementación personalizada de una operación cuando uno o ambos operandos son de ese tipo¹.

Por ejemplo, en el código que me proporcionaste, la clase `Coordenada` sobrecarga los operadores `+` y `-` para permitir la suma y resta de objetos `Coordenada` y la resta de un objeto `Coordenada` con un entero. Esto se logra mediante la definición de métodos estáticos con la palabra clave `operator` y el símbolo del operador que se está sobrecargando¹.

Hay algunas reglas y restricciones para la sobrecarga de operadores. Por ejemplo, no todos los operadores pueden ser sobrecargados y al menos uno de los operandos debe ser del tipo que contiene la declaración del operador¹. Además, no se puede cambiar la precedencia o la asociatividad de los operadores sobrecargados³.

Origen: Conversación con Bing, 8/21/2023
(1) Sobrecarga de operadores: defina los operadores unarios, aritméticos .... https://learn.microsoft.com/es-es/dotnet/csharp/language-reference/operators/operator-overloading.
(2) Tema 15 Sobrecarga de funciones y de operadores - Universidad de Granada. https://bing.com/search?q=sobrecarga+de+operadores.
(3) Sobrecarga de operadores | Microsoft Learn. https://learn.microsoft.com/es-es/cpp/cpp/operator-overloading?view=msvc-170.
(4) Reglas generales para la sobrecarga de operadores. https://learn.microsoft.com/es-es/cpp/cpp/general-rules-for-operator-overloading?view=msvc-170.

****************************************************************************************/