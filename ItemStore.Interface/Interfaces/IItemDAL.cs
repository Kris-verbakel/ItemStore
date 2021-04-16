using ItemStore.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Interface.Interfaces
{
    public interface IItemDAL
    {
        List<ItemDTO> GetAllItems();
        void CreateItem(string name, string brand, double price, string image, string description);
        void DeleteItem(int ID); 
        void UpdateItem(int ID, string name, string brand, double price, string image, string description);
        ItemDTO GetItemById(int ID); 
    }
}
