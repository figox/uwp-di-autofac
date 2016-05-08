using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Autofac;
using UWPDIDemo.Services;
using UWPDIDemo.Interfaces;

namespace UWPDIDemo.Test
{
    [TestClass]
    public class GreetTest
    {
        private static IContainer _container { get; set; }

        public GreetTest() {
            var builder = new ContainerBuilder();
            builder.RegisterType<FakeGreeter>().As<IGreeting>();
            _container = builder.Build();
        }

        [TestMethod]
        public void SayHiTest()
        {
            var expected = "Hi there from testing!";

            using (var scope = _container.BeginLifetimeScope())
            {
                IGreeting greeter = scope.Resolve<IGreeting>();
                var result = greeter.SayHi();

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void SayByeTest()
        {
            var expected = "Good bye testing!";

            using (var scope = _container.BeginLifetimeScope())
            {
                IGreeting greeter = scope.Resolve<IGreeting>();
                var result = greeter.SayBye();

                Assert.AreEqual(expected, result);
            }
        }
    }
}
