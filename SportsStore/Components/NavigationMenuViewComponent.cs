using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IStoreRepository _repository;
        public NavigationMenuViewComponent(IStoreRepository repo)
        {
            _repository = repo;
        }
        public IViewComponentResult Invoke() 
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            var model = _repository.Products.Select(x => x.Category).Distinct().OrderBy(x =>x);

            return View(model);
        }

    }
}
