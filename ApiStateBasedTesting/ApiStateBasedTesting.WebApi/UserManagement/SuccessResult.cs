using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStateBasedTesting.WebApi.UserManagement
{
    public class SuccessResult<S, E> : IResult<S, E>
    {
        private readonly S success;

        public SuccessResult(S success)
        {
            this.success = success;
        }

        public TResult Accept<TResult>(IResultVisitor<S, E, TResult> visitor)
        {
            return visitor.VisitSuccess(success);
        }
    }
}