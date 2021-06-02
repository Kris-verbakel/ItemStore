using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemStore.Logic.Interfaces;
using ItemStore.Logic.Models.Item;
using ItemStore.Presentation.ViewModels.ItemViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItemStore.Presentation.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemContainer _itemContainer;
        private readonly IItemModel _itemModel;
        private readonly IUserContainer _userContainer; 
        
        public ItemController(IItemContainer itemContainer, IUserContainer userContainer, IItemModel itemModel)
        {
            _itemContainer = itemContainer;
            _userContainer = userContainer;
            _itemModel = itemModel; 
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
        public IActionResult CreateItem(CreateItemViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = _userContainer.GetUserByUserName(User.Identity.Name);

                ItemModel itemModel = new ItemModel
                {
                    Brand = model.Brand, 
                    Name = model.Name,
                    Description = model.Description, 
                    Image = model.Image, 
                    Price = model.Price
                };

                _itemContainer.CreateItem(itemModel, user.ID);
                return RedirectToAction("ListItems" , "Item"); 
            }
            return View(model); 
        }

        [HttpGet]
        public IActionResult Item(int id)
        {
            var item = _itemContainer.GetItemById(id);

            ItemViewModel model = new ItemViewModel(item); 
            return View(model);  
        }

        public IActionResult DeleteItem(int id)
        {
            _itemContainer.DeleteItem(id);
            return RedirectToAction("ListItems" , "Item"); 
        }

        [HttpGet]
        public IActionResult EditItem(int id)
        {
            var item = _itemContainer.GetItemById(id);

            return View(new ItemViewModel(item));
        }

        [HttpPost]
        public IActionResult EditItem(ItemViewModel model)
        {
            ItemModel itemModel = new ItemModel
            {
                Brand = model.Brand,
                Name = model.Name,
                Description = model.Description,
                Image = model.Image,
                Price = model.Price
            };

            if (ModelState.IsValid)
            {
                _itemModel.UpdateItem(model.ID, itemModel); 
            }
            return View(model); 
        }
    }
}
