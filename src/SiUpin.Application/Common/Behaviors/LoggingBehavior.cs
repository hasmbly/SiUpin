using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using SiUpin.Application.Common.Interfaces;

namespace SiUpin.Application.Common.Behaviors
{
    public class LoggingBehavior<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly ICurrentUserService _currentUser;

        public LoggingBehavior(ILogger<TRequest> logger, ICurrentUserService currentUser)
        {
            _logger = logger;
            _currentUser = currentUser;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            string requestName = typeof(TRequest).Name;
            string username = _currentUser.IsAuthenticated ? _currentUser.Username : "ANONYMOUS";

            _logger.LogInformation("Application Request: {Name} {@Username}",
                requestName, username);

            return Task.CompletedTask;
        }
    }
}