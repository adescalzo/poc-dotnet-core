using System;
using Newtonsoft.Json;

namespace TestHttpContextExternal.Models
{
    public partial class DollarPriceModel
    {
        [JsonProperty("oficial")]
        public DollarPriceDetailModel Oficial { get; set; }

        [JsonProperty("blue")]
        public DollarPriceDetailModel Blue { get; set; }

        [JsonProperty("oficial_euro")]
        public DollarPriceDetailModel OficialEuro { get; set; }

        [JsonProperty("blue_euro")]
        public DollarPriceDetailModel BlueEuro { get; set; }

        [JsonProperty("last_update")]
        public DateTimeOffset LastUpdate { get; set; }
    }

    public class DollarPriceDetailModel
    {
        [JsonProperty("value_avg")]
        public double ValueAvg { get; set; }

        [JsonProperty("value_sell")]
        public double ValueSell { get; set; }

        [JsonProperty("value_buy")]
        public double ValueBuy { get; set; }
    }
}
