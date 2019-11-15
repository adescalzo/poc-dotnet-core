using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStateBasedTesting.WebApi.UserManagement
{
    public class OkNegotiatedContentResult<T> : ActionResult
    {
        public OkNegotiatedContentResult(T content)
        {
            this.Content = content;
        }

        public T Content { get; }
    }
}
