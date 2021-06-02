using ItemStore.Logic.Models.Item;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItemStore.Presentation.ViewModels.ItemViewModels
{
    public class ItemViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Item name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Item brand")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Display(Name = "Image URL")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
        [Required]
        [Display(Name = "Description")   ]
        public string Description { get; set; }
        public int UserID { get; set; }

        public ItemViewModel(ItemModel itemModel)
        {
            this.ID = itemModel.ID; 
            this.Name = itemModel.Name;
            this.Brand = itemModel.Brand;
            this.Image = itemModel.Image;
            this.Description = itemModel.Description;
            this.Price = itemModel.Price;
            this.UserID = itemModel.UserID; 
        }

        public ItemViewModel()
        {

        }
    }
}
