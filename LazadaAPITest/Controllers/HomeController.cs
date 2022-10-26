using HtmlAgilityPack;
using LazadaAPITest.Data;
using LazadaAPITest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace LazadaAPITest.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;

        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //CLEAR ALL OLD DATA FROM DATABASE

            _db.ShopInfo.RemoveRange(_db.ShopInfo);
            _db.DescriptionInfo.RemoveRange(_db.DescriptionInfo);
            _db.RatingInfo.RemoveRange(_db.RatingInfo);
            _db.ProductDetail.RemoveRange(_db.ProductDetail);
            _db.ProductOverView.RemoveRange(_db.ProductOverView);
            _db.CategoryInfo.RemoveRange(_db.CategoryInfo);
            _db.SaveChanges();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchTextRequest req)
        {
            try
            {
                //GET LIST OF SEARCHED PRODUCTS VIA SENDO API
                var searchUrl = $"https://x.o-s.io/sda?a_slot=top&a_type=product&cli_ubid=18ddb1f0-1659-4611-9390-de9a36fe7e70&client_id=18662&country=VN&currency=VND&" +
                                          $"keywords%5B0%5D={req.SearchText}&language=vi&page_type=SEARCH&pcnt=30";
                var productDetailUrl = $"https://detail-api.sendo.vn/full/";

                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36");

                var content = await client.GetStringAsync(searchUrl);
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(content);

                var jsonProductUrlOject = JObject.Parse(htmlDoc.DocumentNode.InnerText).ToString();
                var productUrlList = JsonConvert.DeserializeObject<ProductsList>(jsonProductUrlOject);

                var productDetailList = new List<ProductOverView>();

                if (productUrlList != null && productUrlList.Products.Any())
                {
                    var htmlDocProductDetail = new HtmlDocument();

                    foreach (var item in productUrlList.Products)
                    {
                        item.ProductUrl = item.ProductUrl.Replace("https://www.sendo.vn/", "").Replace(".html", "");

                        string contentDetail = "";

                        productDetailUrl += item.ProductUrl;
                        try
                        {
                            contentDetail = await client.GetStringAsync(productDetailUrl);
                        }
                        catch
                        {
                            productDetailUrl = $"https://detail-api.sendo.vn/full/";
                            continue;
                        }

                        htmlDocProductDetail.LoadHtml(contentDetail);
                        productDetailUrl = $"https://detail-api.sendo.vn/full/";

                        var jsonProductDetailObject = JObject.Parse(htmlDocProductDetail.DocumentNode.InnerText).ToString();

                        var productDetail = JsonConvert.DeserializeObject<ProductOverView>(jsonProductDetailObject);
                        productDetail.SearchText = req.SearchText;
                        productDetailList.Add(productDetail);
                    }
                    _db.ProductOverView.AddRange(productDetailList);
                    _db.SaveChanges();
                }
                    return View(productDetailList);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        public IActionResult ProductDetail(string Id)
        {
            try
            {
                if (string.IsNullOrEmpty(Id))
                {
                    return NotFound();
                }

                var productDetail = _db.ProductDetail.Include(x => x.Category_Info)
                                                                            .Include(x => x.Description_Info)
                                                                            .Include(x => x.Rating_Info)
                                                                            .Include(x => x.Shop_Info)
                                                                            .Where(x => x.Id == Id).FirstOrDefault();

                if (productDetail == null)
                {
                    return NotFound();
                }
                return View(productDetail);
            }
            catch (Exception)
            {
                return Error();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
