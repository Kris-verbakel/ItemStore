using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ItemStore.Presentation.ViewModels.ItemViewModels
{
    public class CreateItemViewModel
    {
        [Required]
        [Display(Name = "Item name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Item brand")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Image URL")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
