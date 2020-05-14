using System;
using System.Threading;
using System.Threading.Tasks;
using CvLab.MicroserviceTemplate1.MessageProcessing;
using Microsoft.Extensions.Hosting;
using Rebus.Activation;
using Rebus.Bus;
using Rebus.Config;
using Rebus.Handlers;
using CvLab.MicroserviceTemplate1.MessageProcessing.Handlers;

namespace CvLab.MicroserviceTemplate1.Service
{
    internal class RebusHost : IHostedService
    {
        private readonly IBus _bus;

        public RebusHost(IBus bus)
        {
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _bus.Subscribe<SampleMessage1>();

            Console.WriteLine("<RebusHost started!>");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _bus.Unsubscribe<SampleMessage1>();

            Console.WriteLine("<RebusHost stopped!>");
        }
    }
}
