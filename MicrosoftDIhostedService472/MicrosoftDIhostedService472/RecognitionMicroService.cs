using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicrosoftDIhostedService472
{
    public class RecognitionMicroService : IHostedService
    {
        private IRecognitionManager _manager;
        public RecognitionMicroService(IRecognitionManager manager)
        {
            this._manager = manager;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(null);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult<object>(null);
        }
    }
}
