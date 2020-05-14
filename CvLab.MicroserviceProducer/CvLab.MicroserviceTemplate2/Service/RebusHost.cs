using System;
using System.Threading;
using System.Threading.Tasks;
using CvLab.MicroserviceTemplate2.MessageProcessing;
using Microsoft.Extensions.Hosting;
using Rebus.Bus;
using Rebus.Activation;
using Rebus.Config;

using CvLab.MicroserviceTemplate2.SenderClass;

namespace CvLab.MicroserviceTemplate2.Service
{
    internal class RebusHost : IHostedService
    {
        BuiltinHandlerActivator adapter = new BuiltinHandlerActivator();
        private readonly IBus _bus;

        public RebusHost(IBus bus)
        {
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        }

        void Send()
        {
            var sender = new Sender(_bus);

            var keepRunning = true;

            while (keepRunning)
            {
                Console.Write("Enter the message:");
                string mes = Console.ReadLine();
                sender.Send(mes);
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Service started!");
            Send();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Service stopped! Press Enter to quit!");
            Console.ReadLine();
        }
    }
}
