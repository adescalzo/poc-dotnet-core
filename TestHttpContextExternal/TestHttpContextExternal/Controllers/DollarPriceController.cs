using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestHttpContextExternal.Models;
using TestHttpContextExternal.Services;

namespace TestHttpContextExternal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DollarPriceController : ControllerBase
    {
        private readonly ILogger<DollarPriceController> logger;
        private readonly IDollarPriceService dollarPriceService;

        public DollarPriceController(ILogger<DollarPriceController> logger, IDollarPriceService dollarPriceService)
        {
            this.logger = logger;
            this.dollarPriceService = dollarPriceService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var data = await dollarPriceService.FetchCurrent();
            return data;
        }
    }
}
