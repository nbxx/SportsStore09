using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;
using Vic.SportsStore.WebApp.Models;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        public const int PageSize = 3;

        public IProductsRepository Repository { get; set; }

        public ViewResult List(string category, int page = 1)
        {
            var result = Repository
                .Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);

            var pagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = Repository
                .Products
                .Where(p => category == null || p.Category == category)
                .Count(),
            };

            var vm = new ProductsListViewModel
            {
                Products = result,
                PagingInfo = pagingInfo,
                CurrentCategory = category,
            };

            return View(vm);
        }
    }
}