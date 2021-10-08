using BidOn.Service;
using BidOn.Web.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BidOn.Web.Controllers
{
    public class DashBoardController : Controller
    {
        #region usermanager
        private BidOnUserManager _userManager;
        private BidOnRoleManager _roleManager;
        public DashBoardController()
        {
        }

        public DashBoardController(BidOnUserManager userManager, BidOnRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
        }
        public BidOnUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<BidOnUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public BidOnRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<BidOnRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        #endregion
        // GET: DashBoard
        public ActionResult Index()
        {
            DashBoardViewModel model = new DashBoardViewModel();

            model.Auctions =AuctionsService.Instance.GetAllAuction();
            model.Categories = CategoryService.Instance.AllCategories();
            model.BidOnUserCount = BidOnUserManager.GetUserCount();
            model.Bids = BidsService.Instance.AllBids();
            model.BidOnRoles = RoleManager.Roles.ToList();
            model.BidOnComment = CommentsService.Instance.TotalComments();

            return PartialView(model);

        }
    }
}