using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        public const int PageSize = 3;

        public IProductsRepository Repository { get; set; }

        public ViewResult List(int page = 1)
        {
            var result = Repository
                .Products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);

            return View(result);
        }
    }
}