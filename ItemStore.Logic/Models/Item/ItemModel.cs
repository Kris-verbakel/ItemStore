using ItemStore.Interface.DTO;
using ItemStore.Interface.Interfaces;
using ItemStore.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Logic.Models.Item
{
    public class ItemModel : IItemModel
    {
        private readonly IItemModelDAL _itemModelDAL;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int UserID { get; set; }

        public ItemModel(ItemDTO itemDTO)
        {
            this.ID = itemDTO.ID;
            this.Name = itemDTO.Name;
            this.Brand = itemDTO.Brand;
            this.Price = itemDTO.Price;
            this.Image = itemDTO.Image;
            this.Description = itemDTO.Description;
            this.UserID = itemDTO.UserID;  
        }

        public ItemModel(IItemModelDAL itemModelDAL)
        {
            _itemModelDAL = itemModelDAL; 
        }

        public ItemModel()
        {

        }

        public void UpdateItem(int ID, ItemModel itemModel)
        {
            ItemDTO itemDTO = new ItemDTO
            {
                Brand = itemModel.Brand,
                Name = itemModel.Name,
                Description = itemModel.Description,
                Image = itemModel.Image,
                Price = itemModel.Price
            };
            _itemModelDAL.UpdateItem(ID, itemDTO);
        }
    }
}
