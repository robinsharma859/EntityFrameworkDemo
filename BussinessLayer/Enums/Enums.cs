using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Enums
{
    
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,
        [Display(Name = "Female")]
        Female,
        [Display(Name = "Transgender")]
        Transgender
    }

    public enum SecurityQuestion
    {
        [Display(Name = "What is your Favourite PetName")]
        PetName,
        [Display(Name = "What is Best Friend Name")]
        FriendName,
        [Display(Name = "What is your Favourite Car Name")]
        FavouriteCar
    }
     
    class Enums
    {
    }
}
