using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Instagram.Models
{
    public class ImagesPost
    {
        [Key]
        public int? Id { get; set; }
        public int? ImageId { get; set; }
        [ForeignKey("ImageId")]
        public Image? image { get; set; }
        public int? PostId { get; set; }
        [ForeignKey("PostId")]
        public Post? post { get; set; }
    }
}
