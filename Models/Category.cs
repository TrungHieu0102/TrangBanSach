using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    public class Category
    {
        [Key]// Khoa chinh
        public int Id { get; set; }
        [Required]// Not null
        public string Name { get; set; }    

        public int DisplayOrder { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

    }
}
