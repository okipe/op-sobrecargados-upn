using System;
using MisClases.ES;

// Definiremos una estructura y no una clase, de esta forma no será necesario implementar un método para hacer una copia profunda de un complejo en otro.
public struct Complejo
{
    private double real; // parte real
    private double imag; // parte imaginaria

    static private string[] mensajeError =
    {
        "división por cero",
        "Log(0)",
        "en Pow(z, e), z = 0"
    };

    // Manipulación de un error (por ejemplo, división por cero)
    public static void Error(string mensaje)
    {
        Console.WriteLine("\u0007error: " + mensaje);
        System.Environment.Exit(-1);
    }

    // Constructores
    public Complejo(double r, double i)
    {
        real = r; imag = i;
    }

    // Conversión de un double en un complejo. La parte real es igual que double, la parte imaginaria es cero.
    public static implicit operator Complejo(double d)
    {
        return new Complejo(d, 0);
    }

    // Paso de forma polar a binómica: m(cos alfa + isen alfa) = a+bi
    public static Complejo Po_bi(double mod, double alfa)
    {
        return new Complejo(mod * Math.Cos(alfa), mod * Math.Sin(alfa));
    }

    // Operaciones aritméticas con complejos
    public static Complejo operator +(Complejo x, Complejo y)
    {
        return new Complejo(x.real + y.real, x.imag + y.imag);
    }
    public static Complejo operator -(Complejo x, Complejo y)
    {
        return new Complejo(x.real - y.real, x.imag - y.imag);
    }
    public static Complejo operator *(Complejo x, Complejo y)
    {
        return new Complejo(x.real * y.real - x.imag * y.imag,
        x.real * y.imag + x.imag * y.real);
    }
    public static Complejo operator /(Complejo x, Complejo y)
    {
        double r = 0, i = 0, divisor = y.Norm();
        if (divisor != 0)
        {
            r = (x.real * y.real + x.imag * y.imag) / divisor;
            i = (x.imag * y.real - x.real * y.imag) / divisor;
        }
        else
            Complejo.Error(mensajeError[0]);
        return new Complejo(r, i);
    }

    // Comparación de complejos
    public static bool operator ==(Complejo x, Complejo y)
    {
        return (x.real == y.real) && (x.imag == y.imag);
    }
    public static bool operator !=(Complejo x, Complejo y)
    {
        return !(x == y);
    }

    // Métodos adicionales
    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }
    public override bool Equals(object obj)
    {
        return base.Equals(obj); // invoca a ValueType.Equals
    }
    // Para el resto de las comparaciones, comparamos módulos
    public static bool operator <(Complejo x, Complejo y)
    {
        return x.Mod() < y.Mod();
    }
    public static bool operator >(Complejo x, Complejo y)
    {
        return x.Mod() > y.Mod();
    }
    public static bool operator <=(Complejo x, Complejo y)
    {
        return x.Mod() <= y.Mod();
    }
    public static bool operator >=(Complejo x, Complejo y)
    {
        return x.Mod() >= y.Mod();
    }

    // Operaciones trigonométricas con complejos
    public static Complejo Cos(Complejo c)
    {
        return new Complejo(Math.Cos(c.real) * Math.Cosh(c.imag),
        -Math.Sin(c.real) * Math.Sinh(c.imag));
    }
    public static Complejo Sin(Complejo c)
    {
        return new Complejo(Math.Sin(c.real) * Math.Cosh(c.imag),
        Math.Cos(c.real) * Math.Sinh(c.imag));
    }
    public static Complejo Tan(Complejo c)
    {
        return Sin(c) / Cos(c);
    }
    public static Complejo Cosh(Complejo c)
    {
        return new Complejo(Math.Cosh(c.real) * Math.Cos(c.imag),
        Math.Sinh(c.real) * Math.Sin(c.imag));
    }
    public static Complejo Sinh(Complejo c)
    {
        return new Complejo(Math.Sinh(c.real) * Math.Cos(c.imag),
        Math.Cosh(c.real) * Math.Sin(c.imag));
    }
    public static Complejo Tanh(Complejo c)
    {
        return Sinh(c) / Cosh(c);
    }

    // Operaciones logarítmicas y exponenciales
    public static Complejo Exp(Complejo c)
    {
        double m = Math.Exp(c.real);
        return new Complejo(m * Math.Cos(c.imag), m * Math.Sin(c.imag));
    }
    public static Complejo Log(Complejo c)
    {
        double m = c.Mod();
        if (m == 0) Complejo.Error(mensajeError[1]);
        return new Complejo(Math.Log(m), c.Arg());
    }

    // Potencia
    public static Complejo Pow(Complejo c, Complejo e)
    {
        if (e.real == 0 && e.imag == 0)
            return new Complejo(1, 0);
        else
        if (c.real == 0 && c.imag == 0)
            Complejo.Error(mensajeError[2]);
        return Exp(Log(c) * e);
    }

    // Raíz cuadrada
    public static Complejo Sqrt(Complejo c)
    {
        return Pow(c, new Complejo(0.5, 0.0));
    }

    // Representación alfanumérica de un complejo
    public override string ToString()
    {
        return "(" + real + ", " + imag + ")";
    }

    // Leer un complejo
    public static void LeerComplejo(Complejo c)
    {
        double re = 0, im = 0;
        bool error = false;
        do
        {
            Console.Write("real: "); re = Leer.datoDouble();
            Console.Write("imag: "); im = Leer.datoDouble();
            if (error = Double.IsNaN(re) || Double.IsNaN(im))
                Console.WriteLine("Datos incorrectos");
        }
        while (error);
        c.real = re; c.imag = im;
    }

    // Obtención de valores
    public double ParteReal { get { return real; } }
    public double ParteImag { get { return imag; } }
    public double Mod() { return Math.Sqrt(real * real + imag * imag); }
    public double Arg() { return Math.Atan2(imag, real); }
    public double Norm() { return real * real + imag * imag; }

    // Operaciones varias
    public Complejo Conjugado() { return new Complejo(real, -imag); }
    public Complejo Negativo() { return new Complejo(-real, imag); }
    // Menos unario. Complejos opuestos
    public static Complejo operator -(Complejo r)
    {
        return new Complejo(-r.real, -r.imag);
    }
}

/////////////////////////////////////////////////////////////////
// Aplicación para trabajar con el tipo Complejo
//
public class Test
{
    public static void Main(string[] args)
    {
        Complejo a = new Complejo(3.5, -0.7);
        Complejo b = new Complejo(2.0, 1.5);
        Complejo c = -1;
        Complejo d = new Complejo();
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("c = " + c);
        Console.WriteLine("d = " + d);
        double mod = a.Mod();
        Console.WriteLine("mod(a) = " + mod);
        double alfa = a.Arg();
        Console.WriteLine("arg(a) = " + alfa);
        a = -c;
        Console.WriteLine("a = " + a);
        a += b;
        Console.WriteLine("a + b = " + a);
        if (a != new Complejo(0, 0))
        {
            c = b / a;
            Console.WriteLine("b/a = " + c);
        }
        d = Complejo.Po_bi(mod, alfa);
        Console.WriteLine("bi(mod, alfa) = " + d);
        d = Complejo.Tan(b);
        Console.WriteLine("tan(b) = " + d);
        d = Complejo.Pow(a, c);
        Console.WriteLine("pow(a, c) = " + d);
        Complejo.LeerComplejo(d);
        Console.WriteLine("d = " + d);
        a = Complejo.Log(new Complejo(0, 0));
        Console.WriteLine("log(a) = " + a);
    }
}