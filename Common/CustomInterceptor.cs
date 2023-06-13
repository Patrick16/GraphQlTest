using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Http;

namespace Common;

public class CustomInterceptor : DefaultHttpRequestInterceptor
{
    public override ValueTask OnCreateAsync(HttpContext context,
        IRequestExecutor requestExecutor, IQueryRequestBuilder requestBuilder,
        CancellationToken cancellationToken)
    {
        if (context.Request.Headers.TryGetValue("tenant", out var value))
        {
            Console.WriteLine($"tenant: {value}");
        }
        return base.OnCreateAsync(context, requestExecutor, requestBuilder,
            cancellationToken);
    }

}
