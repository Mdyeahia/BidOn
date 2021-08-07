using BidOn.Service;
using BidOn.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BidOn.Web.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Index()
        {
            DashBoardViewModel model = new DashBoardViewModel();

            model.Auctions =AuctionsService.Instance.GetAllAuction();
            model.Bids = BidsService.Instance.AllBids();
            model.BidOnUserCount = BidOnUserManager.GetUserCount();

            return PartialView(model);

        }
    }
}