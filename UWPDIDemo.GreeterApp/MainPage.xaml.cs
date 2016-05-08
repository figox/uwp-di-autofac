using Autofac;
using System.Threading.Tasks;
using UWPDIDemo.Interfaces;
using UWPDIDemo.Services;
using Windows.UI.Xaml.Controls;
using System;

namespace UWPDIDemo.GreeterApp
{
    public sealed partial class MainPage : Page
    {
        private static IContainer _container { get; set; }

        public MainPage()
        {
            DIConfig();
            this.InitializeComponent();
        }

        private void DIConfig()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Greeter>().As<IGreeting>();
            _container = builder.Build();
        }

        private void Hi_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Greet.Text = GetMessage("Hi");
        }

        private void Bye_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Greet.Text = GetMessage("Bye");
        }

        private string GetMessage(string type)
        {
            var msg = "";

            using (var scope = _container.BeginLifetimeScope())
            {
                IGreeting greeter = scope.Resolve<IGreeting>();

                switch (type)
                {
                    case "Hi":
                        msg = greeter.SayHi();
                        break;
                    case "Bye":
                        msg = greeter.SayBye();
                        break;
                }
            }
            
            return msg;
        }
    }
}
