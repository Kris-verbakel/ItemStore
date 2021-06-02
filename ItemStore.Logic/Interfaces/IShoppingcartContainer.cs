using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Logic.Interfaces
{
    public interface IShoppingcartContainer
    {
        void GetItemsByUserID(int userID);
        void AddItemByID(int itemID);
        void RemoveItemByID(int ItemID); 
    }
}
