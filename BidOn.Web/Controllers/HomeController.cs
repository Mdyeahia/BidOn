using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BidOn.Service;
using BidOn.Web.ViewModels;

namespace BidOn.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AuctionsViewModel model = new AuctionsViewModel();

            model.PageTitle = "HomePage";
            model.PageDescription = "This is HomePage";

            model.AllAuctions = AuctionsService.Instance.GetAllAuction();
            model.PromotedAuctions = AuctionsService.Instance.GetPromotedAuctions();

            return View(model);
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