using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStateBasedTesting.WebApi.UserManagement
{
    public interface IUserLookupError
    {
        TResult Accept<TResult>(IUserLookupErrorVisitor<TResult> visitor);
    }
}
