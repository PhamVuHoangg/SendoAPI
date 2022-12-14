using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LazadaAPITest.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display order")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Display order must be greater than 0.")]
        public int DisplayOrder { get; set; }
    }
}
