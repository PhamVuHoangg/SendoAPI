using System.ComponentModel.DataAnnotations;

namespace LazadaAPITest.Models
{
    public class SearchTextRequest
    {
        [Required]
        public string SearchText { get; set; }
    }
}
