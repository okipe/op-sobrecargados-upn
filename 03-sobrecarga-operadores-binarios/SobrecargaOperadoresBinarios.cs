namespace SobrecargaOperadoresBinarios
{
    public class Fraccion
    {
        public int Numerador { get; set; }
        public int Denominador { get; set; }

        // Sobrecarga del operador binario + para sumar dos objetos Fraccion
        public static Fraccion operator +(Fraccion f1, Fraccion f2)
        {
            // Se crea un nuevo objeto Fraccion cuyas propiedades Numerador y Denominador son la suma de las fracciones f1 y f2
            return new Fraccion
            {
                Numerador = f1.Numerador * f2.Denominador + f2.Numerador * f1.Denominador,
                Denominador = f1.Denominador * f2.Denominador
            };
        }

        // Sobrecarga del operador binario - para restar dos objetos Fraccion
        public static Fraccion operator -(Fraccion f1, Fraccion f2)
        {
            // Se crea un nuevo objeto Fraccion cuyas propiedades Numerador y Denominador son la resta de las fracciones f1 y f2
            return new Fraccion
            {
                Numerador = f1.Numerador * f2.Denominador - f2.Numerador * f1.Denominador,
                Denominador = f1.Denominador * f2.Denominador
            };
        }
    }

    class SobrecargaOperadoresBinarios
    {
        static void Main(string[] args)
        {
            // Se crean dos objetos Fraccion con valores iniciales para sus propiedades Numerador y Denominador
            Fraccion f1 = new Fraccion { Numerador = 1, Denominador = 2 };
            Fraccion f2 = new Fraccion { Numerador = 3, Denominador = 4 };

            // Se utiliza la sobrecarga del operador + para sumar los objetos f1 y f2 y se guarda el resultado en el objeto suma
            Fraccion suma = f1 + f2;
            Console.WriteLine($"Suma: {suma.Numerador}/{suma.Denominador}"); // Muestra "Suma: 10/8"

            // Se utiliza la sobrecarga del operador - para restar el objeto f2 al objeto f1 y se guarda el resultado en el objeto resta
            Fraccion resta = f1 - f2;
            Console.WriteLine($"Resta: {resta.Numerador}/{resta.Denominador}"); // Muestra "Resta: -2/8"
        }
    }
}