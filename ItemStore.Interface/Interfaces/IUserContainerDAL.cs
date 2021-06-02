using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Interface.Interfaces
{
    public interface IUserContainerDAL
    {
        UserDTO GetUserByEmail(string email);
        UserDTO GetUserById(int id);
        UserDTO GetUserByUserName(string userName);
        List<UserDTO> GetAllUsers();
        void CreateUser(UserDTO userAcc);
    }
}
