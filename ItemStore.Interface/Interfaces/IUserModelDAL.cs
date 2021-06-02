using ItemStore.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Interface.Interfaces
{
    public interface IUserModelDAL
    {
        void UpdateProfile(int id, UserDTO userAcc);
    }
}
