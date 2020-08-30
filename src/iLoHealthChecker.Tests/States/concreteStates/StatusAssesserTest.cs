using Xunit;

namespace iLoHealthChecker.Tests.States.concreteStates
{

    public class StatusAssesserTest
    {

        [Fact]
        public void state_not_ok_should_trigger_send_email_state()
        {
            // arrange
            var healthResponse = new HealthSummaryResponse();
            var statusAsser = new StatusAssesser();

            // act

            // assert
        }
    }
}