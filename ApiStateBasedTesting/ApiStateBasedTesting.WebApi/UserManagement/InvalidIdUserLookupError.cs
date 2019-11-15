using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStateBasedTesting.WebApi.UserManagement
{
    public class InvalidIdUserLookupError : IUserLookupError
    {
        public TResult Accept<TResult>(IUserLookupErrorVisitor<TResult> visitor)
        {
            return visitor.VisitInvalidId;
        }
    }
}