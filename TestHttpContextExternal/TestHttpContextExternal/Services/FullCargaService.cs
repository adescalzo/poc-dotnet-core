using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TestHttpContextExternal.Models;

namespace TestHttpContextExternal.Services
{
    public interface IFullCargaService
    {
        Task<string> CompaniaFullCargaResponse();
    }

    public class FullCargaService : IFullCargaService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly ILogger<FullCargaService> logger;

        public FullCargaService(ILogger<FullCargaService> logger, IHttpClientFactory clientFactory)
        {
            this.logger = logger;
            this.clientFactory = clientFactory;
        }

        public async Task<string> CompaniaFullCargaResponse()
        {
            logger.LogInformation("Nueva consulta de companias de celulares");

            using (HttpClient httpClient = clientFactory.CreateClient("fullcargas"))
            {
                using (HttpResponseMessage httpResponseMessage = await httpClient.GetAsync("Companias/CompaniasCelular"))
                {
                    var response  = await httpResponseMessage.Content.ReadAsStringAsync();

                    if (!httpResponseMessage.IsSuccessStatusCode)
                    {
                        logger.LogError($"Error: {response}");
                        return string.Empty;
                    }

                    return response;
                }
            }
        }

        public T Deserialize<T>(string json)
            => JsonConvert.DeserializeObject<T>(json);
    }
}
