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
    int thread_number;
    double h;
    decimal[] results;
    int n;
    static readonly object pblock = new object();
    public ExThread(int thread_number, double h, int n){
        this.thread_number=thread_number;
        this.h=h;
        this.n=n;
        this.results = new decimal[thread_number];
    }

    public decimal[] get_results(){
        lock(results){
            return results;
        }
    }
    
    public static double Chebyshev(double x, int n)
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

    public void mythread1(int thread_number, double[] x_array)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        decimal local_results =0;

        for (int i = 0; i < x_array.Length; i++)
        {
            local_results += System.Convert.ToDecimal(h * Chebyshev(x_array[i], this.n));
            // Console.Write(x_array[i] + ",");
        }

        lock(results){
            results[thread_number] = local_results;
        }

        watch.Stop();
        var elapsedMs = watch.ElapsedMilliseconds;


        Console.WriteLine("thread number: " + (thread_number + 1) + "  time: " + elapsedMs + " local result: " + local_results);
    }
}

public class GFG
{
    public static void Main()
    {
        string[] lines = System.IO.File.ReadAllLines("./dane.txt");
        int n = Int32.Parse(lines[0]);
        double a = Double.Parse(lines[1]);
        double b = Double.Parse(lines[2]);
        int N = Int32.Parse(lines[3]);
        double h = (b - a) / N;
        double Fx0 = 0;
        double Fxn = 0;
        decimal Result = 0;
        int thread_number = 10;

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

        double[] Array = new double[N - 2];
        Array = create_array(a, b, N);
        var listOfSplitArray = Array.Split(thread_number);

        var watch1 = System.Diagnostics.Stopwatch.StartNew();

        Fx0 = h / 2 * ExThread.Chebyshev(a, n);
        Fxn = h / 2 * ExThread.Chebyshev(b, n);

        for (int i = 0; i < N - 2; i++)
        {
            Result = Result + System.Convert.ToDecimal(h * ExThread.Chebyshev(Array[i], n));
        }

        Result = Result + System.Convert.ToDecimal(Fx0 + Fxn);

        watch1.Stop();
        var elapsedMs1 = watch1.ElapsedMilliseconds;

        Console.WriteLine("Sequntial Result: " + Result);
        Console.WriteLine("Sequntial Time: " + elapsedMs1);

        ExThread obj = new ExThread(thread_number,h,n);

        Thread[] threads_array = new Thread[thread_number];

        var watch2 = System.Diagnostics.Stopwatch.StartNew();
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

        watch2.Stop();
        var elapsedMs2 = watch2.ElapsedMilliseconds;

        Console.WriteLine("joined add threads");

        decimal thread_result = 0;
        for(int i = 0; i< thread_number; i++){
            thread_result += obj.get_results()[i];
        }
        thread_result += System.Convert.ToDecimal(Fx0 + Fxn);
        Console.WriteLine("Thread Result: " + thread_result);
        Console.WriteLine("Thread Time: " + elapsedMs2);
    }
}