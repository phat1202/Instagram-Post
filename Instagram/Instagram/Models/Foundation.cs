using System.ComponentModel;

namespace Instagram.Models
{
    public class Foundation
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        
    }
}
