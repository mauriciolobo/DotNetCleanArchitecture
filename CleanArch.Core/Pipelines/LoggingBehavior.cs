using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArch.Core.Pipelines
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;

        public LoggingBehavior(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_logger != null)
            {
                _logger.Log(LogLevel.Information,$"Received T request: " + typeof(TRequest).FullName);
                _logger.Log(LogLevel.Information, Newtonsoft.Json.JsonConvert.SerializeObject(request));
            }
            return await next();
        }
    }
}