using System.Collections.Generic;
using Starship.Telemetry;
using Starship.Utility.Math;

namespace Starship.Flight.Command.Actuation.Flap
{
    public readonly struct TopRightFlapActuationCommand : ITelemetryProvider
    {
        public float DeployPercent => _unclampedDeployPercent.Clamp(0.0F, 1.0F);

        private readonly float _unclampedDeployPercent;


        public TopRightFlapActuationCommand(float deployPercent) => _unclampedDeployPercent = deployPercent;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"TopRightFlapDeployPercent:{_unclampedDeployPercent}")
        };
    }
}