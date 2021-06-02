using ItemStore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Logic.Interfaces
{
    public interface IUserModel
    {
        void UpdateProfile(int id, UserModel userModel);
    }
}
