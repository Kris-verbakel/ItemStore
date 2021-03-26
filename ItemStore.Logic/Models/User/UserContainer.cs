using ItemStore.Interface.Interfaces;
using ItemStore.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Logic.Models.User
{
    public class UserContainer : IUserContainer
    {
        private readonly IUserDAL _userDAL;

        public UserContainer(IUserDAL userDAL)
        {
            _userDAL = userDAL; 
        }

        public UserModel GetUserByEmail(string email)
        {
            var userDTO = _userDAL.GetUserByEmail(email);
            return new UserModel(userDTO);
        }

        public UserModel GetUserById(int id)
        {
            var userDTO = _userDAL.GetUserById(id);
            return new UserModel(userDTO); 
        }

        public bool ComparePasswords(string email, string password)
        {
           return _userDAL.ComparePasswords(email, password); 
        }

        public UserModel GetUserByUserName(string userName)
        {
            var userDTO = _userDAL.GetUserByUserName(userName);
            return new UserModel(userDTO); 
        }

        public List<UserModel> GetAllUsers()
        {
            var userDTOs = _userDAL.GetAllUsers();
            var users = new List<UserModel>();

            foreach (var userDTO in userDTOs)
            {
                users.Add(new UserModel(userDTO));
            }
            return users;
        }

        public void CreateUser(string userName, string email, string password, string firstName, string lastName)
        {
            _userDAL.CreateUser(email, userName, firstName, lastName, password); 
        }

        public void UpdateProfile(int id,string userName, string email, string password, string firstName, string lastName)
        {
            _userDAL.UpdateProfile(id, email, userName, firstName, lastName, password); 
        }
    }
}
