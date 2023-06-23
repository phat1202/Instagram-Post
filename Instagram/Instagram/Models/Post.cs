using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models
{
    public class Post : Foundation
    {
        [Key]
        public int? Id { get; set; }
        public string? Content { get; set; }
        public string? ImagePath { get; set; }
        public Image? image { get; set; }
        public User? user { get; set; }
    }
}
