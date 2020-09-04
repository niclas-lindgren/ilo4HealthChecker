using System;
using System.Threading.Tasks;
using NLog;

namespace iloHealthChecker.States.concreteStates
{
    public class Failed : State
    {
        private readonly Logger _log;
        private readonly string _failMessage;
        public Failed(string message)
        {
            _log = LogManager.GetCurrentClassLogger();
            _failMessage = message;
        }
        public override Task Handle()
        {
            return Task.Run(() =>
            {
                _log.Error($"Task failed with message [{_failMessage}]");
                Environment.ExitCode = -1;
            });
        }
    }
}