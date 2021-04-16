﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Logic.Interfaces
{
    public interface IUserContainer
    {
        UserModel GetUserByEmail(string email);
        UserModel GetUserById(int id);
        UserModel GetUserByUserName(string userName);
        List<UserModel> GetAllUsers();
        void CreateUser(string userName, string email, string password, string firstName, string lastName, int role);
        void UpdateProfile(int id, string email, string userName, string firstName, string lastName, string password);
    }
}
