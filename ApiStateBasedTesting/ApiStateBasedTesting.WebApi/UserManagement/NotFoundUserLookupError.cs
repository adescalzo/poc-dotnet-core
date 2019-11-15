using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStateBasedTesting.WebApi.UserManagement
{
    public class NotFoundUserLookupError : IUserLookupError
    {
        public TResult Accept<TResult>(IUserLookupErrorVisitor<TResult> visitor)
        {
            return visitor.VisitNotFound;
        }
    }
}
