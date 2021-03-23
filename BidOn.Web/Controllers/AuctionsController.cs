using BidOn.Entities;
using BidOn.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BidOn.Web.Controllers
{
    public class AuctionsController : Controller
    {
        // GET: Auctions
        public ActionResult Index()
        {
            AuctionsService service = new AuctionsService();
            var auctions = service.GetAllAuction();

            return View(auctions);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            AuctionsService service = new AuctionsService();

            service.SaveAuction(auction);

            return View();
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            AuctionsService service = new AuctionsService();
            var auction=service.GetAuctionById(Id);

            return View(auction);
        }
        [HttpPost]
        public ActionResult Edit(Auction auction)
        {
            AuctionsService service = new AuctionsService();

            service.UpdateAuction(auction);

            return View(auction);
        }
    }
}