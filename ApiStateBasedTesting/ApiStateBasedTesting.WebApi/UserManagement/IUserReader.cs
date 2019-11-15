using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStateBasedTesting.WebApi.UserManagement
{
    public interface IUserReader
    {
        IResult<User, IUserLookupError> Lookup(string id);
    }
}
