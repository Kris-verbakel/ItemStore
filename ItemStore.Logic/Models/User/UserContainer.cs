using ItemStore.Interface;
using ItemStore.Interface.Interfaces;
using ItemStore.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Logic.Models.User
{
    public class UserContainer : IUserContainer
    {
        private readonly IUserContainerDAL _userDAL;

        public UserContainer(IUserContainerDAL userDAL)
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

        public void CreateUser(UserModel user)
        {
            UserDTO newAccountDTO = new UserDTO
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Email = user.Email, 
                City = user.City, 
                Country = user.Country, 
                Adress = user.Adress, 
                PostalCode = user.PostalCode
            };
            _userDAL.CreateUser(newAccountDTO); 
        }
    }
}
