using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BidOn.Entities;
using BidOn.Service;

namespace BidOn.Web.Controllers
{
    public class SharedController : Controller
    {
        // GET: Shared
        [HttpPost]
        public JsonResult UploadPictures()
        {
            JsonResult json = new JsonResult();

            var picturesJson = new List<object>();
            var pictures = Request.Files;

            for (int i = 0; i < pictures.Count; i++)
            {
                var picture = pictures[i];
                var fileName = Guid.NewGuid() + Path.GetExtension(picture.FileName);
                var path = Server.MapPath("~/Content/images/") + fileName;

                var picUrl = "~/Content/images/" + fileName;
                picture.SaveAs(path);//into images  file

                var newPic = new Picture();
                newPic.Url = fileName;
                int picId = SharedService.Instance.SavePicture(newPic);

                picturesJson.Add(new {id=picId,url= fileName});
            }

            json.Data = picturesJson;

            return json;
        }
    }
}