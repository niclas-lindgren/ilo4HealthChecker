using System.Threading.Tasks;
using NLog;

namespace iloHealthChecker.States.concreteStates
{
    public class Completed : State
    {
        private readonly Logger _log;

        public Completed()
        {
            _log = LogManager.GetCurrentClassLogger();
        }
        public override Task Handle()
        {
            return Task.Run(() => { _log.Info("Completed"); });
        }
    }
}