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

            this._loggerSpecific.LogInformation("[INFO SPECIFIC]: RecognitionManager created");

            var privLogger = typeof(Logger<RecognitionManager>).GetField("_logger", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (privLogger != null)
            {
                object value = privLogger.GetValue(loggerSpecific);
                if (value.GetType().FullName == "Serilog.Extensions.Logging.SerilogLogger")
                {
                    Console.WriteLine($"Used Serilog instance, privLogger: {value.GetHashCode()}");
                }
                else
                {
                    Console.WriteLine($"Did NOT used Serilog instance, privLogger: {value.GetHashCode()}");
                }
            }
            else
            {
                Console.WriteLine("There is no private logger");
            }

        }
    }
}
