using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FactoryShopping.Models.AccessModel
{
    public class CartModel
    {
        public int UserId { get; set; }
        public int PId { get; set; }

        public string Name { get; set; } //productname
        public string ImagePath { get; set; }
        public decimal Price { get; set; }
        public int OrderQuantity { get; set; }
        public decimal Amount { get; set; }
    }
}
