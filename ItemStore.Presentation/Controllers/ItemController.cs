using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemStore.Logic.Interfaces;
using ItemStore.Logic.Models.Item;
using ItemStore.Presentation.ViewModels.ItemViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ItemStore.Presentation.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemContainer _itemContainer;
        
        public ItemController(IItemContainer itemContainer)
        {
            _itemContainer = itemContainer; 
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListItems()
        {
            var allItems = _itemContainer.GetAllItems();
            var items = new List<ItemViewModel>(); 

            foreach(var item in allItems)
            {
                var model = new ItemViewModel(item); 
                items.Add(model); 
            }
            return View(items);             
        }

        [HttpGet]
        public IActionResult CreateItem()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult CreateItem(ItemViewModel model)
        {
            if(ModelState.IsValid)
            {
                _itemContainer.CreateItem(model.Name, model.Brand, model.Price, model.Image, model.Description);
                return RedirectToAction("Item, ListItems"); 
            }
            return View(model); 
        }
    }
}
