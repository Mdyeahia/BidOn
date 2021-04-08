using BidOn.Entities;
using BidOn.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BidOn.Web.ViewModels;

namespace BidOn.Web.Controllers
{
    public class AuctionsController : Controller
    {
        // GET: Auctions
        public ActionResult Index()
        {
            AuctionListingViewModel model = new AuctionListingViewModel();
            model.PageTitle = "AuctionsTable";
            model.PageDescription = "List of Auctions";

            return View(model);
        }
        // GET: Auctions
        public ActionResult AuctionsTable()
        {
            AuctionListingViewModel model = new AuctionListingViewModel();

           

            model.AllAuctions = AuctionsService.Instance.GetAllAuction();


            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(CreateAuctionViewModel model)
        {
            Auction auction = new Auction();

            auction.Title = model.Title;
            auction.Description = model.Description;
            auction.ActualAmount = model.ActualAmount;
            auction.StartingTime = model.StartingTime;
            auction.EndTime = model.EndTime;

            var pictureIds = model.AuctionPictures.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            auction.AuctionPictures = new List<AuctionPicture>();
            auction.AuctionPictures.AddRange(pictureIds.Select(x=>new AuctionPicture() { PictureId = x }).ToList());


            AuctionsService.Instance.SaveAuction(auction);

            return RedirectToAction("AuctionsTable");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            
            var auction= AuctionsService.Instance.GetAuctionById(Id);

            return PartialView(auction);
        }
        [HttpPost]
        public ActionResult Edit(Auction auction)
        {


            AuctionsService.Instance.UpdateAuction(auction);

            return RedirectToAction("AuctionsTable");
        }

        
        [HttpPost]
        public ActionResult Delete(int Id)
        {

            AuctionsService.Instance.DeleteAuction(Id);

            return RedirectToAction("AuctionsTable");
        }

        public ActionResult Details(int Id)
        {
            AuctionsViewModel model = new AuctionsViewModel();

            model.PageTitle = "Details";
            model.PageDescription ="Auction details";

            model.Auction= AuctionsService.Instance.GetAuctionById(Id);

            return View(model);
        }
        
    }
}
