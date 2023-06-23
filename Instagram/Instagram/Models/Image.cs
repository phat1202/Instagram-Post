using System.ComponentModel.DataAnnotations;

namespace Instagram.Models
{
    public class Image
    {
        [Key]
        public int? ImageId { get; set; }
        public string? Url { get; set; }
    }
}
