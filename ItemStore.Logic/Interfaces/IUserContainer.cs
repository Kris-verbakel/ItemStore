using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Logic.Interfaces
{
    public interface IUserContainer
    {
        public UserModel GetUserByEmail(string email);
        public UserModel GetUserById(int id);
        public bool ComparePasswords(string email, string password);
        public UserModel GetUserByUserName(string userName);
        public List<UserModel> GetAllUsers(); 
    }
}
