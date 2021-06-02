using ItemStore.Interface;
using ItemStore.Interface.Interfaces;
using ItemStore.Logic.Interfaces;
using System;

namespace ItemStore.Logic
{
    public class UserModel : IUserModel
    {
        private readonly IUserModelDAL _userModelDAL; 
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public UserModel(UserDTO userDTO)
        {
            this.ID = userDTO.ID;
            this.UserName = userDTO.UserName;
            this.Email = userDTO.Email;
            this.FirstName = userDTO.FirstName;
            this.LastName = userDTO.LastName;
            this.Password = userDTO.Password;
            this.Adress = userDTO.Adress;
            this.City = userDTO.City;
            this.Country = userDTO.Country;
            this.PostalCode = userDTO.PostalCode; 
        }

        public UserModel(IUserModelDAL userModelDAL)
        {
            _userModelDAL = userModelDAL; 
        }

        public UserModel()
        {

        }

        public void UpdateProfile(int id, UserModel user)
        {
            UserDTO AccountDTO = new UserDTO
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
            _userModelDAL.UpdateProfile(id, AccountDTO);
        }
    }
}
