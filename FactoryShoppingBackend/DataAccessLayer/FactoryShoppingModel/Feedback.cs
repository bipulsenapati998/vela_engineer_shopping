using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.FactoryShoppingModel
{
    public class Feedback
    {
        [Key]
        public int FeedbackId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User Users { get; set; }

        [ForeignKey("Product")]
        public int PId { get; set; }

        public virtual Product Products { get; set; }

        public string FeedbackReport { get; set; }
    }
}
