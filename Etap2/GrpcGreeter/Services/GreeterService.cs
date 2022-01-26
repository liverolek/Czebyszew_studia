using Grpc.Core;
using GrpcGreeter;

namespace GrpcGreeter.Services{

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

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }    

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

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
       double local_results =0;
        int iterations = 0;
        double[] Array = new double[request.Nvalue - 2];
        Array = create_array(request.Avalue, request.Bvalue, request.Nvalue);
        var listOfSplitArray = Array.Split(request.WorkersCount);
        var arr = listOfSplitArray.ElementAt(request.WorkerNumber).ToArray();
        
        for(int i = 0; i< arr.Length; i++) {
            local_results += request.Hvalue * Chebyshev.CalcChebyshev(arr[i], request.SmallNValue);
            iterations ++ ;
        }
        
        return Task.FromResult(new HelloReply
        {   
            Response = local_results,
            Iterations = iterations
        });
    }
}
}