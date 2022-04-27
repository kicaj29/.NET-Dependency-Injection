using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
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
        private RecognitionSettings _settings;
        public RecognitionMicroService(IRecognitionManager manager, IOptions<RecognitionSettings> settings)
        {
            this._manager = manager;
            this._settings = settings.Value;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.FromResult<object>(null);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.FromResult<object>(null);
        }
    }
}
