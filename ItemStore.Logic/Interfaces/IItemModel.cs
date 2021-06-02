using ItemStore.Interface.DTO;
using ItemStore.Logic.Models.Item;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Logic.Interfaces
{
    public interface IItemModel
    {
        public void UpdateItem(int ID, ItemModel itemModel);
    }
}
