using System;
using System.Collections.Generic;
using System.Text;

namespace SwagLabsTestFramework.Data
{
    class Product
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public string Description { get; set; }
        public string Price { get; set; }

        public Product(string name, int id) {
            Name = Name;
            Id = Id;
        }
        public Product() { }
    }
}
