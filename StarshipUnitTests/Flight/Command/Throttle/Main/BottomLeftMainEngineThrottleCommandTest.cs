using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command.Throttle.Main;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Command.Throttle.Main
{
    public sealed class BottomLeftMainEngineThrottleCommandTest
    {
        [Test]
        public void Should_clamp_and_expose_the_commanded_throttle_percent()
        {
            // GIVEN
            var commandA = new BottomLeftMainEngineThrottleCommand(-0.1F);
            var commandB = new BottomLeftMainEngineThrottleCommand(0.0F);
            var commandC = new BottomLeftMainEngineThrottleCommand(0.5F);
            var commandD = new BottomLeftMainEngineThrottleCommand(1.0F);
            var commandE = new BottomLeftMainEngineThrottleCommand(1.1F);

            // THEN
            Assert.That(commandA.ThrottlePercent, Is.EqualTo(0.0F));
            Assert.That(commandB.ThrottlePercent, Is.EqualTo(0.0F));
            Assert.That(commandC.ThrottlePercent, Is.EqualTo(0.5F));
            Assert.That(commandD.ThrottlePercent, Is.EqualTo(1.0F));
            Assert.That(commandE.ThrottlePercent, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_provide_telemetry_with_the_unclamped_throttle_percent()
        {
            // GIVEN
            var command = new BottomLeftMainEngineThrottleCommand(1.1F);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("BottomLeftMainEngineThrottlePercent:1,1")
            };

            Assert.That(command.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandA = new BottomLeftMainEngineThrottleCommand(0.5F);
            var commandB = new BottomLeftMainEngineThrottleCommand(0.5F);
            var commandC = new BottomLeftMainEngineThrottleCommand(1.0F);

            // THEN
            Assert.That(commandA.Equals(commandB), Is.True);
            Assert.That(commandA.Equals(commandC), Is.False);
        }
    }
}