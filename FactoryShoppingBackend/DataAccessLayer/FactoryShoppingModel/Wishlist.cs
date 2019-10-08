using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.FactoryShoppingModel
{
    public class Wishlist
    {
        [Key]
        public int WishId { get; set; }

        [ForeignKey("Product")]
        public int PId { get; set; }

        public virtual Product Products { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User Users { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public DateTime WishDate { get; set; }

        public int WishQuantity { get; set; }
    }
}
