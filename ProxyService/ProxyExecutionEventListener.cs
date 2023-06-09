using HotChocolate.Execution.Instrumentation;
using HotChocolate.Execution;

namespace ProxyService
{
    public class ProxyExecutionEventListener : ExecutionDiagnosticEventListener
    {
        private readonly ILogger<ProxyExecutionEventListener> _logger;

        public ProxyExecutionEventListener(ILogger<ProxyExecutionEventListener> logger)
            => _logger = logger;

        public override void RequestError(IRequestContext context,
            Exception exception)
        {
            _logger.LogError(exception, "A request error occurred!");
        }

        public override IDisposable ExecuteRequest(IRequestContext context)
        {
            _logger.LogInformation("Process request:{@Request}", context.Request.Query);
            return base.ExecuteRequest(context);
        }
    }
}
