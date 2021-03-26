using ItemStore.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Logic.Models.Item
{
    public class ItemModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public ItemModel(ItemDTO itemDTO)
        {
            this.ID = itemDTO.ID;
            this.Name = itemDTO.Name;
            this.Brand = itemDTO.Brand;
            this.Price = itemDTO.Price;
            this.Image = itemDTO.Image;
            this.Description = itemDTO.Description; 
        }
    }
}
