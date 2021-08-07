using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BidOn.Entities;
using BidOn.Service;
using BidOn.Web.ViewModels;

namespace BidOn.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? categoryId, string search, int? pageNo)
        {

            AuctionsViewModel model = new AuctionsViewModel();
            model.CategoryId = categoryId;
            model.SearchTerm = search;
            model.PageNo = pageNo;
            model.PageTitle = "HomePage";
            model.PageDescription = "This is HomePage";
            model.EntityId = (int)EntitiesEnum.Auction;
            model.PromotedAuctions = AuctionsService.Instance.GetPromotedAuctions();

            return View(model);
        }
        public PartialViewResult HomeAuctionList(int? categoryId, string search, int? pageNo)
        {
            var pageSize = 6;
            pageNo = pageNo ?? 1;

            AuctionsViewModel model = new AuctionsViewModel();

            model.PageTitle = "HomePage";
            model.PageDescription = "This is HomePage";
            model.CategoryId = categoryId;
            model.SearchTerm = search;
            model.AllAuctions = AuctionsService.Instance.FilterAuctions(categoryId, search, pageNo.Value, pageSize);
            //model.PromotedAuctions = AuctionsService.Instance.GetPromotedAuctions();
            model.EntityId= (int)EntitiesEnum.Auction;

            var totalAuctions = AuctionsService.Instance.GetAuctionCount(categoryId, search);
            model.pager = new Pager (totalAuctions, pageNo, pageSize );

            return PartialView(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}