using System;
using System.Collections.Generic;
using System.Text;

namespace ItemStore.Interface.DTO
{
    public class ItemDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int UserID { get; set; }
    }
}
