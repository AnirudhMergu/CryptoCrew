using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;

namespace CryptoCrew.Controllers
{
    public class CertController : Controller
    {
        [HttpPost]  
        public ActionResult Upload(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    if (fileName.EndsWith(".pfx") || fileName.EndsWith(".cer"))
                    {
                        var path = Path.Combine(Server.MapPath("~/App_Data/Certificates/"), fileName);
                        file.SaveAs(path);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                ViewBag.Message = "Upload successful";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("Uploads");
            }
        }

        public ActionResult Uploads()
        {
            return View("Uploads", ViewBag.Message);
        }

        public ActionResult Downloads()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/App_Data/Certificates/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.cer");
            List<string> items = new List<string>();

            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }

            return View(items);
        }

        public FileResult Download(string ImageName)
        {
            return File("~/App_Data/Certificates/" + ImageName, System.Net.Mime.MediaTypeNames.Text.Plain);
        }

        // GET: Cert
        public ActionResult Index()
        {
            return View();
        }
    }
}