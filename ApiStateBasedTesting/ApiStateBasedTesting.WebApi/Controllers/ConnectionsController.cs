using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiStateBasedTesting.WebApi.UserManagement;
using Microsoft.AspNetCore.Mvc;

namespace ApiStateBasedTesting.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionsController : ControllerBase
    {
        public ConnectionsController(
            IUserReader userReader,
            IUserRepository userRepository)
        {
            UserReader = userReader;
            UserRepository = userRepository;
        }

        public IUserReader UserReader { get; }
        public IUserRepository UserRepository { get; }

        public ActionResult Post(string userId, string otherUserId)
        {
            var userRes = UserReader.Lookup(userId).SelectError(
                error => error.Accept(UserLookupError.Switch(
                    onInvalidId: "Invalid user ID.",
                    onNotFound: "User not found.")));

            var otherUserRes = UserReader.Lookup(otherUserId).SelectError(
                error => error.Accept(UserLookupError.Switch(
                    onInvalidId: "Invalid ID for other user.",
                    onNotFound: "Other user not found.")));

            var connect =
                from user in userRes
                from otherUser in otherUserRes
                select Connect(user, otherUser);

            return connect.SelectBoth(Ok, BadRequest).Bifold();
        }

        protected ActionResult BadRequest(string message)
        {
            return base.BadRequest(message);
        }

        protected ActionResult Ok<T>(T content)
        {
            return base.Ok(content);
        }

        private User Connect(User user, User otherUser)
        {
            user.Connect(otherUser);
            UserRepository.Update(user);

            return otherUser;
        }
    }
}
