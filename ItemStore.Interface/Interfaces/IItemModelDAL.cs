using ItemStore.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Interface.Interfaces
{
    public interface IItemModelDAL
    {
        void UpdateItem(int ID, ItemDTO itemDTO);
    }
}
