using System;
using UWPDIDemo.Interfaces;

namespace UWPDIDemo.Services
{
    public class Greeter : IGreeting
    {
        public string SayBye()
        {
            return "Good bye!";
        }

        public string SayHi()
        {
            return "Hi there!";
        }
    }
}
