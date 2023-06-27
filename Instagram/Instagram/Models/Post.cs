using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models
{
    public class Post : Foundation
    {
        [Key]
        public int? Id { get; set; }
        public string? Content { get; set; }
        public int? ImageId { get; set; }
        [ForeignKey("ImageId")]
        public Imagez? image { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public Userz? user { get; set; }
        
    }
}
