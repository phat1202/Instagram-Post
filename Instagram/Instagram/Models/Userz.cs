using System.ComponentModel.DataAnnotations;

namespace Instagram.Models
{
    public class Userz
    {
        [Key]
        public int? UserId { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        public string? UserName { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string? Password {  get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
        public string? Avatar { get; set; }
    }
}
