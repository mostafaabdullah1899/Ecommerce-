using System.ComponentModel.DataAnnotations;


namespace Final_Project.ViewModel
{
    public class RegisterVM
    {
        [Key]
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }
       
        [Required]
        public string PhoneNumber { get; set; }

    }
}
