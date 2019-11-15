using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStateBasedTesting.WebApi.UserManagement
{
    public interface IUserLookupErrorVisitor<TResult>
    {
        TResult VisitInvalidId { get; }
        TResult VisitNotFound { get; }
    }
}
