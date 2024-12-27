

using System.Diagnostics.Metrics;

namespace Livestream.Infrastructure.Metrics
{
    public class LivestreamMetrics
    {
        public static readonly Meter Meter = new("Livestream.Metrics");
    public static readonly Counter<int> LivestreamsCreated = Meter.CreateCounter<int>("products_created");
    }
}