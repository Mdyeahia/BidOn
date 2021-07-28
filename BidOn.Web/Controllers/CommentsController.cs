using BidOn.Entities;
using BidOn.Service;
using BidOn.Web.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BidOn.Web.Controllers
{
    public class CommentsController : Controller
    {
        
        public JsonResult LeaveComment(CommentsViewModel model)
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    var comment = new Comment();

                    comment.Text = model.Text;
                    comment.Rating = model.Rating;
                    comment.Timestamp = DateTime.Now;
                    comment.EntityId = model.EntityId;
                    comment.RecordId = model.RecordId;
                    comment.UserId = User.Identity.GetUserId();

                    CommentsService.Instance.LeaveComment(comment);


                    result.Data = new { success = true };
                }
                else
                {
                    result.Data = new { success = false, message = "Invalid input.", isSwitchUrl = false };
                }

            }
            else
            {
                result.Data = new { success = false, message = "you've to login in first.", isSwitchUrl = true };
            }

            return result;
        }
    }
}