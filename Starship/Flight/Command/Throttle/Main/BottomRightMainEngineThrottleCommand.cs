using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Throttle.Main
{
    public sealed class BottomRightMainEngineThrottleCommand : ITelemetryProvider
    {
        public float ThrottlePercent { get; }


        public BottomRightMainEngineThrottleCommand(float throttlePercent)
        {
            ThrottlePercent = throttlePercent;
        }

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomRightMainEngineThrottlePercent:{ThrottlePercent}")
        };
    }
}