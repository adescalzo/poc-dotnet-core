using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStateBasedTesting.WebApi.UserManagement
{
    public interface IResult<S, E>
    {
        TResult Accept<TResult>(IResultVisitor<S, E, TResult> visitor);
    }
}
