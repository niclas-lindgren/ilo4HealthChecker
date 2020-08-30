using System;

namespace iloHealthChecker.Exceptions
{
    class EnvironmentVariableException : Exception
    {

        public EnvironmentVariableException(string message) : base(message)
        {
        }
    }
}