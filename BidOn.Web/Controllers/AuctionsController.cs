using BidOn.Entities;
using BidOn.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            
            

            return View();
        }
        // GET: Auctions
        public ActionResult AuctionsTable()
        {
            AuctionsService service = new AuctionsService();
            var auctions = service.GetAllAuction();


            return PartialView(auctions);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            AuctionsService service = new AuctionsService();

            service.SaveAuction(auction);

            return RedirectToAction("AuctionsTable");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            AuctionsService service = new AuctionsService();
            var auction=service.GetAuctionById(Id);

            return PartialView(auction);
        }
        [HttpPost]
        public ActionResult Edit(Auction auction)
        {
            AuctionsService service = new AuctionsService();

            service.UpdateAuction(auction);

            return RedirectToAction("AuctionsTable");
        }

        
        [HttpPost]
        public ActionResult Delete(int Id)
        {
            AuctionsService service = new AuctionsService();
            service.DeleteAuction(Id);

            return RedirectToAction("AuctionsTable");
        }
        
    }
}
