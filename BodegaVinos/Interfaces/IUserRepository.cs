﻿using System.Collections.Generic;
using BodegaVinos.Entities;


namespace BodegaVinos.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Add(User user);
        void Update(User user);
        void Delete(int id);
    }
}
