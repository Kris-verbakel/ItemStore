using ItemStore.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Interface.Interfaces
{
    public interface IItemContainerDAL
    {
        List<ItemDTO> GetAllItems();
        void CreateItem(ItemDTO itemDTO, int userID);
        void DeleteItem(int ID); 
        ItemDTO GetItemById(int ID); 
    }
}
