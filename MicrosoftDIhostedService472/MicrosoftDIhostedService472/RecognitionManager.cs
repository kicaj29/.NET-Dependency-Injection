using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDIhostedService472
{
    public class RecognitionManager : IRecognitionManager
    {
        private readonly ILogger<RecognitionManager> _loggerSpecific;
        public RecognitionManager(ILogger<RecognitionManager> loggerSpecific)
        {
            this._loggerSpecific = loggerSpecific;

            // by checking in watch window loggerSpecific its private _logger field
            // we can see that it is instance of Serilog
        }
    }
}
