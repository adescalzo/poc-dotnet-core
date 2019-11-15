using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStateBasedTesting.WebApi.UserManagement
{
    public interface IResultVisitor<S, E, TResult>
    {
        TResult VisitSuccess(S success);
        TResult VisitError(E error);
    }
}
