using ItemStore.Interface;
using System;

namespace ItemStore.Logic
{
    public class UserModel
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public UserModel(UserDTO userDTO)
        {
            this.ID = userDTO.ID;
            this.UserName = userDTO.UserName;
            this.Email = userDTO.Email;
            this.FirstName = userDTO.FirstName;
            this.LastName = userDTO.LastName;
            this.Password = userDTO.Password;
        }
    }
}
