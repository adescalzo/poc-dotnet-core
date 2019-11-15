using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStateBasedTesting.WebApi.UserManagement
{
    public class BadRequestErrorMessageResult : ActionResult
    {
        public BadRequestErrorMessageResult(string message)
        {
            this.Message = message;
        }

        public string Message { get; }
    }
}
