using Newtonsoft.Json;

namespace TestHttpContextExternal.Models
{
    public class CompaniaFullCargasResponse
    {
        [JsonProperty("mensaje")]
        public string Mensaje { get; set; }

        [JsonProperty("transaccionSosMovil")]
        public string TransaccionSosMovil { get; set; }
    }
}
