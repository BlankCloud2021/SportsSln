using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository _storeRepository;
        public int PageSize = 4;
        public HomeController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public IActionResult Index(string category ,int productPage = 1)
        {
            var model = new ProductsListViewModel
            {
                Products = _storeRepository.Products.Where(p => p.Category == category || category == null).OrderBy(p => p.ProductID).Skip((productPage - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    _storeRepository.Products.Count() :
                    _storeRepository.Products.Where(e =>
                    e.Category == category).Count()
                }
            }; 
            return View(model);
        }
    }
}
