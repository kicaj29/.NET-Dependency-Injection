using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
        private readonly IRecognitionManager _manager;
        private readonly RecognitionSettings _settings;
        private readonly ILogger<RecognitionMicroService> _loggerSpecific;
        // private readonly ILogger _loggerGeneral;

        public RecognitionMicroService(IRecognitionManager manager, IOptions<RecognitionSettings> settings,
            ILogger<RecognitionMicroService> loggerSpecific)
        {
            // by checking in watch window loggerSpecific its private _logger field
            // we can see that it is instance of Serilog

            this._manager = manager;
            this._settings = settings.Value;
            this._loggerSpecific = loggerSpecific;
            // this._loggerGeneral = loggerGeneral;

            this._loggerSpecific.LogInformation("[INFO SPECIFIC]: RecognitionMicroService created");
            // this._loggerGeneral.LogInformation("[INFO GENERAL]: RecognitionMicroService created");
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
