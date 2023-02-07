using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BussinessLayer.Models
{
    public class ViewModel
    {

        public int LoginId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        [Required(ErrorMessage = "Enter User Name ")]
        [Remote("IsAlreadySigned", "Register", HttpMethod = "POST", ErrorMessage = "User Name already exists, Please select another .")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(10, MinimumLength = 7)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecureityAnswer { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Text)]
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public Nullable<int> LoggedIn { get; set; }
    }
}

