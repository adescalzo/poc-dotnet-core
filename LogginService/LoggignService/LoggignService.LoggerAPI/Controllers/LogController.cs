using LoggignService.LoggerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System.Collections.Generic;

namespace LoggignService.LoggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private static readonly ILogger logger = LogManager.GetLogger(typeof(LogController).FullName);

        [HttpPost]
        public ActionResult Post([FromBody] LoggingModel loggingModel)
        {
            logger.Log(ConvertToLogLevel(loggingModel.Level), string.Format("[{0}] {1}", loggingModel.ServiceName, loggingModel.Message));

            return Ok();
        }

        private static IDictionary<string, LogLevel> TranslationStringToLogLevel = new Dictionary<string, LogLevel>()
                    {
                        { "trace", LogLevel.Trace },
                        { "info", LogLevel.Info },
                        { "debug", LogLevel.Debug },
                        { "error", LogLevel.Error },
                        { "fatal", LogLevel.Fatal },
                    };


        private LogLevel ConvertToLogLevel(string logLevel)
        {
            if (!TranslationStringToLogLevel.ContainsKey(logLevel.ToLower()))
            {
                return LogLevel.Trace;
            }

            return TranslationStringToLogLevel[logLevel.ToLower()];
        }

    }
}