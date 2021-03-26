using ItemStore.Interface.Interfaces;
using ItemStore.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Logic.Models.Item
{
    public class ItemContainer : IItemContainer 
    {
        private readonly IItemDAL _itemDAL;

        public ItemContainer(IItemDAL itemDAL)
        {
            _itemDAL = itemDAL; 
        }
        public List<ItemModel> GetAllItems()
        {
            var itemDTOs = _itemDAL.GetAllItems();
            var items = new List<ItemModel>();

            foreach (var itemDTO in itemDTOs)
            {
                items.Add(new ItemModel(itemDTO));
            }
            return items;
        }

        public void CreateItem(string name, string brand, double price, string image, string description)
        {
            _itemDAL.CreateItem(name, brand, price, image, description); 
        }
        public void DeleteItem(int ID)
        {
            _itemDAL.DeleteItem(ID); 
        }
        public void UpdateItem(int ID, string name, string brand, double price, string image, string description)
        {
            _itemDAL.UpdateItem(ID, name, brand, price, image, description); 
        }
    }
}
