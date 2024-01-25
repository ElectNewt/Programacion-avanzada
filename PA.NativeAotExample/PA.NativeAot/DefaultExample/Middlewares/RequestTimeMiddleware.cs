using System.Diagnostics;

namespace DefaultExample.Middlewares;

public class RequestTimeMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        await next(context);
        stopWatch.Stop();

        TimeSpan ts = stopWatch.Elapsed;
        Console.WriteLine($"Default App Execution Time: {ts.Microseconds} microseconds");
    }
}