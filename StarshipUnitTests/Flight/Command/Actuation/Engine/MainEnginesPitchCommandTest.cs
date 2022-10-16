using System.Collections.Generic;
using NUnit.Framework;
using Starship.Flight.Command.Actuation.Engine;
using Starship.Telemetry;

namespace StarshipUnitTests.Flight.Command.Actuation.Engine
{
    public sealed class MainEnginesPitchCommandTest
    {
        [Test]
        public void Should_clamp_and_expose_the_commanded_pitch_percent()
        {
            // GIVEN
            var commandA = new MainEnginesPitchCommand(-1.1F);
            var commandB = new MainEnginesPitchCommand(-1.0F);
            var commandC = new MainEnginesPitchCommand(0.0F);
            var commandD = new MainEnginesPitchCommand(1.0F);
            var commandE = new MainEnginesPitchCommand(1.1F);

            // THEN
            Assert.That(commandA.PitchPercent, Is.EqualTo(-1.0F));
            Assert.That(commandB.PitchPercent, Is.EqualTo(-1.0F));
            Assert.That(commandC.PitchPercent, Is.EqualTo(0.0F));
            Assert.That(commandD.PitchPercent, Is.EqualTo(1.0F));
            Assert.That(commandE.PitchPercent, Is.EqualTo(1.0F));
        }

        [Test]
        public void Should_provide_telemetry_with_the_unclamped_pitch_percent()
        {
            // GIVEN
            var command = new MainEnginesPitchCommand(1.1F);

            // THEN
            var expectedTelemetry = new List<TelemetryMessage>
            {
                new TelemetryMessage("MainEnginesPitchPercent:1,1")
            };

            Assert.That(command.ProvideTelemetry(), Is.EqualTo(expectedTelemetry));
        }

        [Test]
        public void Should_provide_a_equality_by_value_method()
        {
            // GIVEN
            var commandA = new MainEnginesPitchCommand(0.5F);
            var commandB = new MainEnginesPitchCommand(0.5F);
            var commandC = new MainEnginesPitchCommand(1.0F);

            // THEN
            Assert.That(commandA.Equals(commandB), Is.True);
            Assert.That(commandA.Equals(commandC), Is.False);
        }
    }
}