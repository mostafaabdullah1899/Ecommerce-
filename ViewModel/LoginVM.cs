using System.ComponentModel.DataAnnotations;

namespace Final_Project.ViewModel
{
    public class LoginVM
    {
        [Key]
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
