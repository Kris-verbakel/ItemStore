using ItemStore.Interface.DTO;
using ItemStore.Interface.Interfaces;
using ItemStore.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Logic.Models.Item
{
    public class ItemContainer : IItemContainer 
    {
        private readonly IItemContainerDAL _itemContainerDAL;

        public ItemContainer(IItemContainerDAL itemDAL)
        {
            _itemContainerDAL = itemDAL; 
        }
        public List<ItemModel> GetAllItems()
        {
            var itemDTOs = _itemContainerDAL.GetAllItems();
            var items = new List<ItemModel>();

            foreach (var itemDTO in itemDTOs)
            {
                items.Add(new ItemModel(itemDTO));
            }
            return items;
        }

        public ItemModel GetItemById(int ID)
        {
            var item = _itemContainerDAL.GetItemById(ID);
            return new ItemModel(item); 
        }

        public void CreateItem(ItemModel item, int userID)
        {
            ItemDTO itemDTO = new ItemDTO
            {
                Brand = item.Brand,
                Name = item.Name,
                Description = item.Description,
                Image = item.Image,
                Price = item.Price
            };

            _itemContainerDAL.CreateItem(itemDTO, userID); 
        }
        public void DeleteItem(int ID)
        {
            _itemContainerDAL.DeleteItem(ID); 
        }
    }
}
