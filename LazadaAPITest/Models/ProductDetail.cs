using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LazadaAPITest.Models
{
    public class ProductDetail
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Short_Description { get; set; }
        public List<CategoryInfo> Category_Info { get; set; }
        public int Quantity { get; set; }
        public ShopInfo Shop_Info { get; set; }
        public DescriptionInfo Description_Info { get; set; }
        public RatingInfo Rating_Info { get; set; }

    }
    public class ShopInfo
    {
        [Key]
        public int Id { get; set; }
        public string Shop_Id { get; set; }
        public string Shop_Name { get; set; }
        public string Shop_Logo { get; set; }
        public string Phone_Number { get; set; }
        public float Rating_Avg { get; set; }
        public int Rating_Count { get; set; }
        public int Product_Total { get; set; }
        public string Warehourse_Region_Name { get; set; }
    }
    public class CategoryInfo
    {
        [Key]
        public int dbId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class DescriptionInfo
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
    public class RatingInfo
    {
        [Key]
        public int Id { get; set; }
        public int Total_Rated { get; set; }
        public float Percent_Star { get; set; }
        public float Percent_Star1 { get; set; }
        public float Percent_Star2 { get; set; }
        public float Percent_Star3 { get; set; }
        public float Percent_Star4 { get; set; }
        public float Percent_Star5 { get; set; }
        public int Star1 { get; set; }
        public int Star2 { get; set; }
        public int Star3 { get; set; }
        public int Star4 { get; set; }
        public int Star5 { get; set; }

    }
}
