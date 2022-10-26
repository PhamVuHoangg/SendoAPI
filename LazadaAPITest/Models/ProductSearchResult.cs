using System.Collections.Generic;

namespace LazadaAPITest.Models
{
    public class ProductsList
    {
        public List<ProductSearchResult> Products { get; set; }
    }
    public class ProductSearchResult
    {
        public string ProductUrl { get; set; }
    }
}
