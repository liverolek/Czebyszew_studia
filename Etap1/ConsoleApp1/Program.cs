using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public static class ArrayExtensions
{
    public static IEnumerable<IEnumerable<T>> Split<T>(this T[] array, int splitInto)
    {
        var initialValue = array.Length / splitInto;
        var itemsLeft = array.Length - initialValue * splitInto;
        var itemsQuantityList = new List<int>();
        for (var i = 0; i < splitInto; i++)
        {
            if (i < itemsLeft)
            {
                itemsQuantityList.Add(initialValue + 1);
            }
            else
            {
                itemsQuantityList.Add(initialValue);
            }
        }
        var splitArray = new List<List<T>>();
        var sum = 0;
        for (var i = 0; i < splitInto; i++)
        {
            splitArray.Add(array.Skip(sum).Take(itemsQuantityList.ElementAt(i)).ToList());
            sum = +itemsQuantityList.ElementAt(i);
        }
        return splitArray;
    }
}

public class ExThread
{

    public void mythread1(int thread_number, double[] x_array)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        System.Threading.Thread.Sleep(1000 * thread_number);
        Console.WriteLine();

        for (int i = 0; i < x_array.Length; i++)
        {

            Console.Write(x_array[i] + ",");
        }

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;


        Console.WriteLine("thread number: " + (thread_number + 1) + "  time: " + elapsedMs);
    }
}

public class GFG
{
    public static void Main()
    {
        //Link do pliku z parametrami!!!
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\01122363\Desktop\Dane.txt");

        int n = Int32.Parse(lines[0]);
        double a = Double.Parse(lines[1]);
        double b = Double.Parse(lines[2]);
        int N = Int32.Parse(lines[3]);

        double h = (b - a) / N;
        double Fx0 = 0;
        double Fxn = 0;
        decimal Result = 0;
        int thread_number = 10;


        var watch = System.Diagnostics.Stopwatch.StartNew();

        double Chebyshev(double x)
        {
            double T1, T2, T3;
            double F = 0;

            T1 = 1;
            T2 = x;
            T3 = 0;

            for (int i = 0; i < n; i++)
            {
                T3 = 2 * x * T2 - T1;
                T1 = T2;
                T2 = T3;
            }
            F = Math.Sqrt(Math.Sqrt(Math.Abs(T3)));

            return F;
        }

        double[] create_array(double a, double b, int N)
        {
            double[] array = new double[N - 2];
            double delta = (b - a) / (N - 1);

            array[0] = a + delta;

            for (int i = 0; i < N - 3; i++)
            {
                array[i + 1] = array[i] + delta;
            }

            return array;
        }

        double Fx = Chebyshev(3);
        double[] Array = new double[N - 2];
        Array = create_array(a, b, N);
        var listOfSplitArray = Array.Split(thread_number);

        //Tu masz Andrzej ilosc podzielonych tablic
        Console.WriteLine(listOfSplitArray.Count());


        foreach (var element in listOfSplitArray)
        {
            element.ToArray();
            foreach (var element2 in element)
            {
                //wypisuje kazdy element z nowej tablicy
                Console.WriteLine(element2);
            }
            Console.WriteLine("The end of current array");
        }

        Fx0 = h / 2 * Chebyshev(a);
        Fxn = h / 2 * Chebyshev(b);

        for (int i = 0; i < N - 2; i++)
        {
            Result = Result + System.Convert.ToDecimal(h * Chebyshev(Array[i]));
        }

        Result = Result + System.Convert.ToDecimal(Fx0 + Fxn);

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;

        Console.WriteLine("Result: " + Result);
        Console.WriteLine("time: " + elapsedMs);

        ExThread obj = new ExThread();

        Thread[] threads_array = new Thread[thread_number];
        for (var i = 0; i < threads_array.Length; i++)
        {
            var xd = i;
            threads_array[i] = new Thread(() => obj.mythread1(xd, listOfSplitArray.ElementAt(xd).ToArray()));
            threads_array[i].Start();
        }

        for (int i = 0; i < threads_array.Length; i++)
        {
            threads_array[i].Join();
        }
        Console.WriteLine("joined add threads");
    }
}