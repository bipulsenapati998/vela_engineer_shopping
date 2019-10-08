using DataAccessLayer.FactoryShoppingModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FactoryShopping.Models.FactoryShoppingModel
{
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Product")]
        public int PId { get; set; }

        public virtual Product Products { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User Users { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public int OrderedQuantity { get; set; }


    }
}
