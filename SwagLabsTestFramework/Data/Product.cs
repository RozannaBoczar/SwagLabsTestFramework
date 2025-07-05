using System;
using System.Collections.Generic;
using System.Text;

namespace SwagLabsTestFramework.Data
{
    public class Product
    {
        public string Name { get; set; }
        public int? Id { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }

        public Product() { }

        public Product(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
