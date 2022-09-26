using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_shop_app.Models
{
    internal class Item
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public int price { get; set; }
        public string img { get; set; }

        public Item()
        {
        }

        public Item(string name, string title, int price, string img)
        {
            this.name = name;
            this.title = title;
            this.price = price;
            this.img = img;
        }


        public string GetImg()
        {
            return "/img/" + img;
        }
    }
}
