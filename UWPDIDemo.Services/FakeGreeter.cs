using System;
using UWPDIDemo.Interfaces;

namespace UWPDIDemo.Services
{
    public class FakeGreeter : IGreeting
    {
        public string SayBye()
        {
            return "Good bye testing!";
        }

        public string SayHi()
        {
            return "Hi there from testing!";
        }
    }
}
