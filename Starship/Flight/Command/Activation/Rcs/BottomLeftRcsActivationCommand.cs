using System.Collections.Generic;
using Starship.Telemetry;

namespace Starship.Flight.Command.Activation.Rcs
{
    public readonly struct BottomLeftRcsActivationCommand : ITelemetryProvider
    {
        public bool Activated { get; }


        public BottomLeftRcsActivationCommand(bool activated) => Activated = activated;

        public IEnumerable<TelemetryMessage> ProvideTelemetry() => new List<TelemetryMessage>
        {
            new TelemetryMessage($"BottomLeftRcsActivated:{Activated}")
        };
    }
}