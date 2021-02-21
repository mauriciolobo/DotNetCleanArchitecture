using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace CleanArch.Core.Infra.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Console.WriteLine($"Received T request: " + typeof(TRequest).FullName);
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(request));
            return await next();
        }
    }
}