using BidOn.Data;
using BidOn.Entities;
using BidOn.Service;
using BidOn.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web; 
using System.Web.Mvc;


namespace BidOn.Web.Controllers
{
    public class UsersController : Controller
    {

        #region usermanager
        private BidOnUserManager _userManager;
        private BidOnRoleManager _roleManager;
        public UsersController()
        {
        }

        public UsersController(BidOnUserManager userManager, BidOnRoleManager roleManager)
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

        //GET: Users
        public ActionResult Index()
        {
           
            UsersViewModel model = new UsersViewModel();
            model.PageTitle = "AuctionsTable";
            model.PageDescription = "List of Auctions";
            //BidOnContext appcontext = new BidOnContext();
            //var allUsers = appcontext.Users.ToList();
            ////var userManager = new UserManager<BidOnUser>(new UserStore<BidOnUser>(appcontext));

            return PartialView(model);
        }
        public  PartialViewResult UsersList(string roleId, string searchTerm, int? pageNo)
        {
            var pageSize = 3;
            pageNo = pageNo ?? 1;


            UsersViewModel model = new UsersViewModel();
            model.SearchTerm = searchTerm;
            model.RoleId = roleId;
            model.Roles = RoleManager.Roles.ToList();

            var users = UserManager.Users;



            if (!string.IsNullOrEmpty(roleId))
            {
                users = users.Where(x => x.Roles.FirstOrDefault(y => y.RoleId == roleId) != null);
            }
            if (!string.IsNullOrEmpty(searchTerm))
            {
                users = users.Where(x => x.Email.ToLower().Contains(searchTerm.ToLower()));
            }
            var skipCount = pageSize * (pageNo.Value - 1);

            model.Users = users.OrderBy(x => x.Email).Skip(skipCount).Take(pageSize).ToList();

            model.pager = new Pager(users.Count(), pageNo, pageSize);


            return PartialView(model);
        }

        public async Task<ActionResult> UserDetails(string Id,bool isPartial=false)
        {
            UserDetailsViewModel model = new UserDetailsViewModel();

            var user =await UserManager.FindByIdAsync(Id);

            if (user != null)
            {
                model.User = user;
            }
            if(isPartial || Request.IsAjaxRequest())
            {
                return PartialView("_UserDetails", model);
            }
            else
            {
                return View(model);
            }
            
        }

        public ActionResult RoleIndex()
        {

            RolesViewModel model = new RolesViewModel();
            model.PageTitle = "AuctionsTable";
            model.PageDescription = "List of Auctions";
            //BidOnContext appcontext = new BidOnContext();
            //var allUsers = appcontext.Users.ToList();
            ////var userManager = new UserManager<BidOnUser>(new UserStore<BidOnUser>(appcontext));

            return PartialView(model);
        }
        public PartialViewResult RoleList(string searchTerm, int? pageNo)
        {
            var pageSize = 3;
            pageNo = pageNo ?? 1;


            RolesViewModel model = new RolesViewModel();
            model.SearchTerm = searchTerm;
            var roles = RoleManager.Roles;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                roles =roles.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()));
            }
            var skipCount = pageSize * (pageNo.Value - 1);

            model.Roles = roles.OrderBy(x => x.Name).Skip(skipCount).Take(pageSize).ToList();

            model.pager = new Pager(roles.Count(), pageNo, pageSize);


            return PartialView(model);
        }

        public async Task<ActionResult> UserRolesDetails(string Id)
        {
            UserDetailsViewModel model = new UserDetailsViewModel();
            model.AvailableRoles = RoleManager.Roles.ToList();
            model.userId = Id;
            if (!string.IsNullOrEmpty(Id))
            {
                var user = await UserManager.FindByIdAsync(Id);
                if (user != null)
                {
                    model.UserRoles = user.Roles.Select
                        (userRole => model.AvailableRoles
                        .FirstOrDefault(role => role.Id == userRole.RoleId))
                        .ToList();
                }
            }

             return PartialView("_UserRolesDetails", model);
            

        }
        public ActionResult AssignRole(string userId, string roleName)
        {
            if (!UserManager.IsInRole(userId, roleName))
            {
            
                UserManager.AddToRole(userId, roleName);
                return RedirectToAction("UserRolesDetails", "Users", new { Id = userId });
                
            }
            
            return RedirectToAction("UserRolesDetails");
        }
        public ActionResult RemoveFromRole(string userId,string roleName)
        {

            
            
            UserManager.RemoveFromRole(userId, roleName);
            //UserManager.AddToRole(userId, "User");

            //TempData["Success"] = "Roles Assigned Successfully";
            return RedirectToAction("UserRolesDetails", "Users", new { Id = userId });
        }


        //public PartialViewResult UsersList()
        //{
        //    UsersViewModel UsersWithRoles = new UsersViewModel();
        //    BidOnContext appcontext = new BidOnContext();
        //    var allUsers = appcontext.Users.ToList();
        //    var userManager = new UserManager<BidOnUser>(new UserStore<BidOnUser>(appcontext));

        //    List<BidOnUser> Adminstrators = new List<BidOnUser>();
        //    List<BidOnUser> Managers = new List<BidOnUser>();
        //    List<BidOnUser> Sellers = new List<BidOnUser>();

        //    foreach (var user in allUsers)
        //    {
        //        if (userManager.IsInRole(user.Id, "Admin"))
        //        {
        //            Adminstrators.Add(user);
        //        }
        //        else if (userManager.IsInRole(user.Id, "Modarator"))
        //        {
        //            Managers.Add(user);
        //        }
        //        else if (userManager.IsInRole(user.Id, "User"))
        //        {
        //            Sellers.Add(user);
        //        }
        //    }

        //    UsersWithRoles.Admin = Adminstrators;
        //    UsersWithRoles.Modarator = Managers;
        //    UsersWithRoles.User = Sellers;

        //    return PartialView(UsersWithRoles);
        //}

    }
}