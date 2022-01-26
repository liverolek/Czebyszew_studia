// See https://aka.ms/new-console-template for more information

// using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;
using Google.Protobuf.Collections;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
// using Grpc.Net.Client;



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

    public class ExThread
    {   
        private int thread_number;
        private double h;
        private double[] results;
        private int n;
        public ExThread(int thread_number, double h, int n){
            this.thread_number=thread_number;
            this.h=h;
            this.n=n;
            this.results = new double[thread_number];
        }
        public double[] get_results(){
            return results;
        }

        async public void mythread1(int thread_number, string port, double[] x_array)
        {   
            Console.WriteLine("starting thread nr " + thread_number);
            var channel = GrpcChannel.ForAddress("http://localhost:"+port, new GrpcChannelOptions
            {
                MaxReceiveMessageSize = 100 * 1024 * 1024, // 100 MB
                MaxSendMessageSize = 100 * 1024 * 1024 // 100 MB
            });
            var client = new Greeter.GreeterClient(channel);
            RepeatedField<double> request = new RepeatedField<double>();
            // Console.WriteLine(request);
            for (int i = 0; i < x_array.Length; i++)
            {
                request.Add(x_array[i]);
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var res = await client.SayHelloAsync(new HelloRequest { Request = {request}, Nvalue = this.n, Hvalue =this.h });
            Console.WriteLine("iterations: ", res.Iterations);
            double  local_results = res.Response;
            lock(results){
                results[thread_number] = local_results;
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("worker number: " + (thread_number + 1) + "  time: " + elapsedMs + " local result: " + local_results);
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
            // necessery data:
            string[] lines = System.IO.File.ReadAllLines("./dane.txt");
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
            ExThread obj = new ExThread(thread_number,h,n);
            Thread[] threads_array = new Thread[thread_number];
            var watch2 = System.Diagnostics.Stopwatch.StartNew();
            for (var i = 0; i < args.Length; i++)
            {
                var xd = i;
                string port = String.Copy(args[i]);
                threads_array[i] = new Thread(() => obj.mythread1(xd, port, listOfSplitArray.ElementAt(xd).ToArray()));
                threads_array[i].Start();
            }
            for (int i = 0; i < args.Length; i++)
            {
                threads_array[i].Join();
            }
            watch2.Stop();
            var elapsedMs2 = watch2.ElapsedMilliseconds;
            Console.WriteLine("joined add threads");
            decimal thread_result = 0;
            for(int i = 0; i< thread_number; i++){
                thread_result += System.Convert.ToDecimal(obj.get_results()[i]);
            }
            thread_result += System.Convert.ToDecimal(Fx0 + Fxn);
            Console.WriteLine("GRPC Result: " + thread_result);
            Console.WriteLine("GRPC Time: " + elapsedMs2);


            // // Early testss: 
            // Console.WriteLine("");
            // Console.WriteLine("Some later tests:");
            // GrpcChannel[] channles = new GrpcChannel[args.Length];
            // for(int i =0; i<args.Length; i++){
            //     Console.WriteLine(args[i]);
            //     channles[i] = GrpcChannel.ForAddress("http://localhost:"+args[i]);
            //     var client = new Greeter.GreeterClient(channles[i]);
            //     RepeatedField<double> request = new RepeatedField<double>();
            //     request.Add(10);
            //     request.Add(11);
            //     Console.WriteLine(request);
            //     var reply = await client.SayHelloAsync(new HelloRequest { Request = {request}, Nvalue = 100, Hvalue =10 });
            //     Console.WriteLine("Greeting: " + reply.Response);
            //     Console.WriteLine("Itearionts: " + reply.Iterations);
            // }
            
            
            
            // The port number must match the port of the gRPC server.
            // var channel = GrpcChannel.ForAddress("http://localhost:9874");
            // var client = new Greeter.GreeterClient(channel);
            // var reply = await client.SayHelloAsync(
            //                 new HelloRequest { Name = "GreeterClient" });
            // Console.WriteLine("Greeting: " + reply.Message);
            // Console.WriteLine("Press any key to exit...");
            // Console.ReadKey();
        }
    }
}
