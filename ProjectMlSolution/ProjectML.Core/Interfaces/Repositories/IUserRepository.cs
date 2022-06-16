﻿using ProjectML.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectML.Core.Interfaces
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<User> Add(User user);
        public Task<User> Update(User user);
        public Task<User> GetById(int? userId);
        public Task<User> DeleteById(int? userId);
    }
}
