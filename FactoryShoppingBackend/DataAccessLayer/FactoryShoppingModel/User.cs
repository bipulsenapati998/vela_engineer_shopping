using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.FactoryShoppingModel
{
   public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType (DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is Required")]
        [StringLength(100, ErrorMessage = "Password must be 6 Characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

         
        public string Mobile { get; set; }

        public string Profile_Image { get; set; }

        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
   
        public virtual Role Role { get; set; } 

        //public virtual Role roles { get; set; }

    }
}
