using BidOn.Entities;
using BidOn.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BidOn.Web.Controllers
{
    public class BidsController : Controller
    {
        // GET: Bids
        public JsonResult Bid(int auctionId)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            if (User.Identity.IsAuthenticated)
            {
                Bid bid = new Bid();

                bid.AuctionId = auctionId;
                bid.Timestamp = DateTime.Now;
                bid.UserId = User.Identity.GetUserId();
                bid.BidAmount = 10;

                var bidResult = BidsService.Instance.AddBid(bid);
                if (bidResult)

                    result.Data = new { success = true };
                else
                    result.Data = new { success = false, message = "Unable to Bid!" };
            }
            else
            {
                result.Data = new { success = false, message = "You have to log in first !" };
            }
            return result;
        }
    }
}