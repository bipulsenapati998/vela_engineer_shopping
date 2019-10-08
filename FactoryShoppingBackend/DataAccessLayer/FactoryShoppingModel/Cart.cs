using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.FactoryShoppingModel
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("Product")]
        public int PId { get; set; }

        public virtual Product Products { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User Users { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public int OrderQuantity { get; set; }
        public DateTime CartDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal CartTotal { get; set; }

    }
}
