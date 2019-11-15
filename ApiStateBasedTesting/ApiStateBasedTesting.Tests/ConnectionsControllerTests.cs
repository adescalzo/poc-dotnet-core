using ApiStateBasedTesting.WebApi.Controllers;
using ApiStateBasedTesting.WebApi.UserManagement;
using AutoFixture;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace ApiStateBasedTesting.Tests
{
    public class ConnectionsControllerTests
    {
        [Theory, UserManagementTestConventions]
        public void UsersSuccessfullyConnect(
            [Frozen(Matching.ImplementedInterfaces)]FakeDB db,
            User user,
            User otherUser,
            ConnectionsController sut)
        {
            db.Add(user);
            db.Add(otherUser);
            db.IsDirty = false;

            var actual = sut.Post(user.Id.ToString(), otherUser.Id.ToString());

            var ok = Assert.IsAssignableFrom<OkResult>( actual);

            Assert.Equal(otherUser, ok.Content);
            Assert.True(db.IsDirty);
            Assert.Contains(otherUser.Id, user.Connections);
        }

        [Theory, UserManagementTestConventions]
        public void UsersFailToConnectWhenUserIdIsInvalid(
            [Frozen(Matching.ImplementedInterfaces)]FakeDB db,
            string userId,
            User otherUser,
            ConnectionsController sut)
        {
            Assert.False(int.TryParse(userId, out _));
            db.Add(otherUser);
            db.IsDirty = false;

            var actual = sut.Post(userId, otherUser.Id.ToString());

            var err = Assert.IsAssignableFrom<BadRequestObjectResult>(actual);
            Assert.Equal("Invalid user ID.", err.Value);
            Assert.False(db.IsDirty);
        }

        [Theory, UserManagementTestConventions]
        public void UsersFailToConnectWhenOtherUserIdIsInvalid(
            [Frozen(Matching.ImplementedInterfaces)]FakeDB db,
            User user,
            string otherUserId,
            ConnectionsController sut)
        {
            Assert.False(int.TryParse(otherUserId, out _));
            db.Add(user);
            db.IsDirty = false;

            var actual = sut.Post(user.Id.ToString(), otherUserId);

            var err = Assert.IsAssignableFrom<BadRequestObjectResult>(actual);
            Assert.Equal("Invalid ID for other user.", err.Value);
            Assert.False(db.IsDirty);
        }

        [Theory, UserManagementTestConventions]
        public void UsersDoNotConnectWhenUserDoesNotExist(
            [Frozen(Matching.ImplementedInterfaces)]FakeDB db,
            int userId,
            User otherUser,
            ConnectionsController sut)
        {
            db.Add(otherUser);
            db.IsDirty = false;

            var actual = sut.Post(userId.ToString(), otherUser.Id.ToString());

            var err = Assert.IsAssignableFrom<BadRequestObjectResult>(actual);
            Assert.Equal("User not found.", err.Value);
            Assert.False(db.IsDirty);
        }

        [Theory, UserManagementTestConventions]
        public void UsersDoNotConnectWhenOtherUserDoesNotExist(
            [Frozen(Matching.ImplementedInterfaces)]FakeDB db,
            User user,
            int otherUserId,
            ConnectionsController sut)
        {
            db.Add(user);
            db.IsDirty = false;

            var actual = sut.Post(user.Id.ToString(), otherUserId.ToString());

            var err = Assert.IsAssignableFrom<BadRequestObjectResult>(actual);
            Assert.Equal("Other user not found.", err.Value);
            Assert.False(db.IsDirty);
        }
    }
}
