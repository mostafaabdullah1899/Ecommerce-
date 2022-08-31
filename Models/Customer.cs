using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models
{
    public class Customer:IdentityUser<int>
    {   
        [Required]
        public string Address { get; set; }
    
       
        public virtual List<Order>? Orders { get; set; }
    }
}
