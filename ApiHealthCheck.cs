using Microsoft.Extensions.Diagnostics.HealthChecks;
using Nest;
using System.Threading;
using System.Threading.Tasks;

namespace WebAdvert.Search.Api
{
    public class ApiHealthCheck : IHealthCheck
    {
        private readonly IElasticClient _elasticClient;
        public ApiHealthCheck(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var health = await _elasticClient.Cluster.HealthAsync();

            if (health.Status == Elasticsearch.Net.Health.Green)
                return HealthCheckResult.Healthy("A healthy result.");
            else
                return HealthCheckResult.Unhealthy("A Unhealthy result.");

        }
    }
}
