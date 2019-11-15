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
    public class FullCargaController : ControllerBase
    {
        private readonly ILogger<FullCargaController> logger;
        private readonly IFullCargaService fullCargaService;

        public FullCargaController(ILogger<FullCargaController> logger, IFullCargaService fullCargaService)
        {
            this.logger = logger;
            this.fullCargaService = fullCargaService;
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var data = await fullCargaService.CompaniaFullCargaResponse();
            return data;
        }
    }
}
