using System.ComponentModel.DataAnnotations;

namespace LazadaAPITest.Models
{
    public class ProductOverView
    {
        [Key]
        public int Id { get; set; }
        public ProductDetail Data { get; set; }
        public string SearchText { get; set; }
    }
}
