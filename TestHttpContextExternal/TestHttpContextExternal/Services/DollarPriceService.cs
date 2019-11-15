using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using TestHttpContextExternal.Models;

namespace TestHttpContextExternal.Services
{
    public interface IDollarPriceService
    {
        Task<string> FetchCurrent();
    }

    public class DollarPriceService : IDollarPriceService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly ILogger<DollarPriceService> logger;

        public DollarPriceService(ILogger<DollarPriceService> logger, IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
            this.logger = logger;
        }

        public async Task<string> FetchCurrent()
        {
            logger.LogInformation("Start get data");
            var now = DateTime.Now;

            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.bluelytics.com.ar/v2/latest");

            request.Headers.Add("Accept", "application/json");

            using (var client = clientFactory.CreateClient())
            {
                var response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    logger.LogError($"{response.StatusCode.ToString()} {response}");
                }

                var responseText = await response.Content.ReadAsStringAsync();
                logger.LogInformation($"Delay {DateTime.Now.Subtract(now).TotalSeconds}");

                return responseText;
            }
        }
    }
}
