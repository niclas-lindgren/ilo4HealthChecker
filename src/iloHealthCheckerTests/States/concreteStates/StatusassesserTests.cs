using System.Net.WebSockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iloHealthChecker.States.concreteStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace iloHealthChecker.States.concreteStates.Tests
{
    [TestClass()]
    public class StatusassesserTests
    {
        [TestMethod()]
        public async void HandleTest()
        {
            var response = new Dictionary<string, string>(){
               {"test1", "OK"}, {"test1", "NOT_OK"}
            };
            var s = new Statusassesser(response);
            await s.Handle();
            Assert.IsNotNull(s.);
        }
    }
}