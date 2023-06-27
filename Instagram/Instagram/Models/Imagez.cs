using System.ComponentModel.DataAnnotations;

namespace Instagram.Models
{
    public class Imagez
    {
        [Key]
        public int? ImageId { get; set; }
        public string? Url { get; set; }
    }
}
