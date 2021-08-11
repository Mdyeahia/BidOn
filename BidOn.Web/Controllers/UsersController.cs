using BidOn.Entities;
using BidOn.Service;
using BidOn.Web.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BidOn.Web.Controllers
{
    public class UsersController : Controller
    {

        #region usermanager
        private BidOnUserManager _userManager;

        public UsersController()
        {
        }

        public UsersController(BidOnUserManager userManager)
        {
            UserManager = userManager;
            
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
        #endregion

        // GET: Users
        public ActionResult Index(string roleId,string search,int? pageNo)
        {
           
            UsersViewModel model = new UsersViewModel();
            model.SearchTerm = search;
            model.RoleId = roleId;
            

            return PartialView(model);
        }
        public PartialViewResult UsersList(string roleId, string search, int? pageNo)
        {
            var pageSize = 2;
            pageNo = pageNo ?? 1;

            UsersViewModel model = new UsersViewModel();
            model.SearchTerm = search;
            model.RoleId = roleId;
            model.Roles = new List<IdentityRole>();
            model.Users = UserManager.Users.ToList();
            model.pager = new Pager(4, pageNo, pageSize);

            return PartialView(model);
        }
    }
}