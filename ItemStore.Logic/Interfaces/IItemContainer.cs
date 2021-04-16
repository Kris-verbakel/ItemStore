using ItemStore.Logic.Models.Item;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Logic.Interfaces
{
    public interface IItemContainer
    {
        List<ItemModel> GetAllItems();
        void CreateItem(string name, string brand, double price, string image, string description);
        void DeleteItem(int ID);
        void UpdateItem(int ID, string name, string brand, double price, string image, string description);
        ItemModel GetItemById(int ID); 
    }
}
