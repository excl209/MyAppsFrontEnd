using log4net;
using log4net.Appender;
using log4net.Core;
using MyAppsFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyAppsFrontEnd.Appender
{
    public class LogAppender : AppenderSkeleton
    {
        ILog log = LogManager.GetLogger(typeof(LogAppender));
        private HttpClient _httpClient = new HttpClient();

        protected async override void Append(LoggingEvent loggingEvent)
        {
            try
            {
                HttpResponseMessage response; 
                using (var client = new HttpClient())
                {
                    LoggingItems log = new LoggingItems()
                    {
                        AppId = 1,
                        Level = loggingEvent.Level.ToString(),
                        Thread = loggingEvent.ThreadName,
                        Message = loggingEvent.RenderedMessage,
                        Timestamp = loggingEvent.TimeStamp,
                        Class = loggingEvent.LoggerName,
                    };

                    response = await client.PostAsJsonAsync($"https://localhost:44379/v1/AddLoggingItems", log);

                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                log.Warn(ex.Message);
            }
        }
    }
}
