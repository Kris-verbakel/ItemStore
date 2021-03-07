﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Interface.Interfaces
{
    public interface IUserDAL
    {
        UserDTO GetUserByEmail(string email);
        bool ComparePasswords(string email, string password);
        UserDTO GetUserById(int id);
        UserDTO GetUserByUserName(string userName);
        List<UserDTO> GetAllUsers(); 
    }
}
