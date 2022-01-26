using Grpc.Core;
using GrpcGreeter;

namespace GrpcGreeter.Services;

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

public class GreeterService : Greeter.GreeterBase
{
    private readonly ILogger<GreeterService> _logger;
    public GreeterService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
    {
        // System.Threading.Thread.Sleep(1000);
        double local_results =0;
        int iterations = 0;
        foreach (double item in request.Request)
        {
            local_results += request.Hvalue * Chebyshev.CalcChebyshev(item, request.Nvalue);
            iterations ++ ;
        }

        return Task.FromResult(new HelloReply
        {   
            Response = local_results,
            Iterations = iterations
        });
    }
}
