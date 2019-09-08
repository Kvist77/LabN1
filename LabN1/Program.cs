using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabN1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Метод дихотомии");
            MethodDihot(0, 1);
            Console.WriteLine("Метод хорд");
            MethodHord(0, 1);
            Console.WriteLine("Метод касательных");
            MethodKasat(0.1);
            Console.ReadKey();
        }


        static double e = 0.0001, x1, x2, fx1, fx2, en, xfinal, fxfinal, n;

        
        //Метод дихотомии
        static void MethodDihot(double a, double b)
        {
            n = 0;
            do
            {
                x1 = (b + a - e) / 2;
                x2 = (b + a + e) / 2;

                fx1 = Math.Pow(x1, 3) - 3 * Math.Sin(x1);
                fx2 = Math.Pow(x2, 3) - 3 * Math.Sin(x2);

                if (fx1 <= fx2)
                {
                    b = x2;
                }
                else
                {
                    a = x1;
                }

                en = (b - a) / 2;
                n = n + 1;
            }
            while (en > e);
            xfinal = (a + b) / 2;
            fxfinal = Math.Pow(xfinal, 3) - 3 * Math.Sin(xfinal);
            
            Console.WriteLine("f(x) = {0} за число итераций n = {1}", fxfinal, n);
        }

        //Первая производная
        static double Proizvod(double x)
        {
            double proiz = 3 * Math.Pow(x, 2) - 3 * Math.Cos(x);
            return proiz;
        }


        //Метод хорд
        static void MethodHord(double a, double b)
        {
            n = 0;
            do
            {
                double fproizB = Proizvod(b), fproizA = Proizvod(a);

                xfinal = a - ((fproizA) / (fproizA - fproizB)) * (a - b);
                fxfinal = Proizvod(xfinal);
                if (Math.Abs(fxfinal) <= e)
                {
                    n += 1;
                    fxfinal = Math.Pow(xfinal, 3) - 3 * Math.Sin(xfinal);
                    Console.WriteLine("f(x) = {0} за число итераций n = {1}", fxfinal, n);
                    return;
                }
                else if (fxfinal < 0)
                {
                    b = xfinal;
                    fproizB = fxfinal;

                }
                else
                {
                    a = xfinal;
                    fproizA = fxfinal;
                }
                n += 1;
            } while (Math.Abs(fxfinal) > e);

            Console.WriteLine("f(x) = {0} за число итераций n = {1}", fxfinal, n);
        }


        //Метод касательных
        static void MethodKasat(double a)
        {
            n = 0;
            do
            {
                xfinal = a - Proizvod(a) / (6 * a + 3 * Math.Sin(a));
                a = xfinal;
                n += 1;
            } while (Proizvod(xfinal)>e);
            fxfinal = Math.Pow(xfinal, 3) - 3 * Math.Sin(xfinal);
            Console.WriteLine("f(x) = {0} за число итераций n = {1}", fxfinal, n);


        }
    }



}
