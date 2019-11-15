﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStateBasedTesting.WebApi.UserManagement
{
    public class User
    {
        private readonly List<int> connections;

        public User(int id)
        {
            Id = id;
            connections = new List<int>();
        }

        public int Id { get; }

        public IReadOnlyCollection<int> Connections => connections;

        public void Connect(User otherUser)
        {
            connections.Add(otherUser.Id);
        }
    }
}