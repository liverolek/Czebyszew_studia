using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;
using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleApp3
{

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
                sum += itemsQuantityList.ElementAt(i);
            }
            return splitArray;
        }
    }

    public static class Chebyshev{
        public static double CalcChebyshev(double x, int n)
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
    }
      
    class Program
    {
        static double[] create_array(double a, double b, int N)
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

        static async Task Main(string[] args)
        {      
            // Data loading
            string[] lines = System.IO.File.ReadAllLines(@"./dane.txt");
            int n = Int32.Parse(lines[0]);                     
            double a = Double.Parse(lines[1]);
            double b = Double.Parse(lines[2]);
            int N = Int32.Parse(lines[3]);
            double h = (b - a) / N;
            double Fx0 = 0;
            double Fxn = 0;
            decimal Result = 0;
            int thread_number = args.Length;
            double[] Array = new double[N - 2];
            Array = create_array(a, b, N);
            var listOfSplitArray = Array.Split(thread_number);

            // Sequential calculations: 
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            Fx0 = h / 2 * Chebyshev.CalcChebyshev(a, n);
            Fxn = h / 2 * Chebyshev.CalcChebyshev(b, n);
            for (int i = 0; i < N - 2; i++)
            {
                Result = Result + System.Convert.ToDecimal(h * Chebyshev.CalcChebyshev(Array[i], n));
            }
            Result = Result + System.Convert.ToDecimal(Fx0 + Fxn);
            watch1.Stop();
            var elapsedMs1 = watch1.ElapsedMilliseconds;
            Console.WriteLine("Sequntial Result: " + Result);
            Console.WriteLine("Sequntial Time: " + elapsedMs1);


            // GRPC calculations:   
            Console.WriteLine("");
            Console.WriteLine("Now using grpc");
           
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            GrpcChannel[] channels = new GrpcChannel[args.Length];
            Greeter.GreeterClient[] clients = new Greeter.GreeterClient[args.Length];
            Grpc.Core.AsyncUnaryCall<HelloReply>[] responses = new Grpc.Core.AsyncUnaryCall<HelloReply>[args.Length];
            HelloReply[] replys = new HelloReply[args.Length];
            for (var i = 0; i < args.Length; i++)
            {
                var xd = i;

                channels[i] = GrpcChannel.ForAddress("http://localhost:"+args[i], new GrpcChannelOptions
                {
                    MaxReceiveMessageSize = 100 * 1024 * 1024, // 100 MB
                    MaxSendMessageSize = 100 * 1024 * 1024 // 100 MB
                });
                clients[i] = new Greeter.GreeterClient(channels[i]);
                RepeatedField<double> request = new RepeatedField<double>();
                var arr = listOfSplitArray.ElementAt(xd).ToArray();
                var req = new HelloRequest { 
                        Nvalue = N,
                        Hvalue = h,
                        WorkersCount = args.Length,
                        WorkerNumber = xd,
                        Avalue = a,
                        Bvalue = b,
                        SmallNValue = n
                };
                Console.WriteLine(req);
                responses[i] = clients[i].SayHelloAsync(req);
                
            }
            var whenall = await Task.WhenAll(responses.Select(c=>c.ResponseHeadersAsync));
            for (var i = 0; i < args.Length; i++)
            {
                replys[i] = await responses[i];
                Console.WriteLine(replys[i]);
            }

            watch2.Stop();
            var elapsedMs2 = watch2.ElapsedMilliseconds;
            decimal thread_result = 0;
            for(int i = 0; i< args.Length; i++){
                thread_result += System.Convert.ToDecimal(replys[i].Response);
            }
            thread_result += System.Convert.ToDecimal(Fx0 + Fxn);
            Console.WriteLine("");
            Console.WriteLine("GRPC Result: " + thread_result);
            Console.WriteLine("GRPC Time: " + elapsedMs2);
        }
    }
}
