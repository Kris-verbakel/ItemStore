using ItemStore.Logic.Models.Item;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Logic.Interfaces
{
    public interface IItemContainer
    {
        List<ItemModel> GetAllItems();
        void CreateItem(ItemModel itemModel, int userID);
        void DeleteItem(int ID);
        ItemModel GetItemById(int ID); 
    }
}
