using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace WebAdvert.Search.Api
{
    public class ApiHealthCheck : IHealthCheck
    {
        public ApiHealthCheck()
        {
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Task.FromResult(HealthCheckResult.Healthy("A healthy result."));
        }
    }
}
