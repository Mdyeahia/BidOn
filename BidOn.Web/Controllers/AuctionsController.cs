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
        public PartialViewResult AuctionsTable(int? categoryId, string search, int? pageNo)
        {
            var pageSize = 3;
            pageNo = pageNo ?? 1;

            AuctionListingViewModel model = new AuctionListingViewModel();
            //model.PageNo= pageNo ?? 1;
            model.CategoryId = categoryId;
            model.SearchTerm = search;
            model.AllAuctions = AuctionsService.Instance.FilterAuctions(categoryId, search,pageNo.Value, pageSize);
            model.Categories = CategoryService.Instance.AllCategories();
            var totalAuctions = AuctionsService.Instance.GetAuctionCount(categoryId, search);

            model.pager = new Pager(totalAuctions, pageNo, pageSize);

            return PartialView(model);


        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateAuctionViewModel model = new CreateAuctionViewModel();
            model.Categories = CategoryService.Instance.AllCategories();

            return PartialView(model);
        }

        [HttpPost]
        public JsonResult Create(CreateAuctionViewModel model)
        {
            JsonResult result = new JsonResult();
            if (ModelState.IsValid) {

                Auction auction = new Auction();

                auction.Title = model.Title;
                auction.Description = model.Description;
                auction.ActualAmount = model.ActualAmount;
                auction.StartingTime = model.StartingTime;
                auction.EndTime = model.EndTime;
                auction.CategoryId = model.categoryId;
                if (!string.IsNullOrEmpty(model.AuctionPictures))
                {
                    var pictureIds = model.AuctionPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                    auction.AuctionPictures = new List<AuctionPicture>();
                    auction.AuctionPictures.AddRange(pictureIds.Select(x => new AuctionPicture() { PictureId = x }).ToList());
                }

                AuctionsService.Instance.SaveAuction(auction);

                result.Data = new { success = true };
            }
            else
            {
                result.Data = new { success = false, message = "Invalid Inputs" };
            }
            return result;
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            CreateAuctionViewModel model = new CreateAuctionViewModel();

            model.Auction = AuctionsService.Instance.GetAuctionById(Id);
            model.Categories = CategoryService.Instance.AllCategories();


            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(CreateAuctionViewModel model)
        {
            //Auction auction =new Auction();

            //auction.Id = model.Id;
            var auction = AuctionsService.Instance.GetAuctionById(model.Id);
            auction.Title = model.Title;
            auction.Description = model.Description;
            auction.ActualAmount = model.ActualAmount;
            auction.StartingTime = model.StartingTime;
            auction.EndTime = model.EndTime;
            auction.CategoryId = model.categoryId;


            if (!string.IsNullOrEmpty(model.AuctionPictures))
            {
                var pictureIds = model.AuctionPictures.Split(',').Select(int.Parse);
                auction.AuctionPictures = new List<AuctionPicture>();
                auction.AuctionPictures.AddRange(pictureIds.Select(x => new AuctionPicture() { AuctionId = auction.Id, PictureId = x }).ToList());

            }



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
            model.PageDescription = "Auction details";

            model.Auction = AuctionsService.Instance.GetAuctionById(Id);

            return View(model);
        }

    }
}
