using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.AccessModel
{
    public class Login
    {
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Password is Required")]       
        public string Password { get; set; }
    }
}
