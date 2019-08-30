using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public string UpLoadFile()
        {
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files["upImage"];
            if (file == null) return "-1";

            string fullName = file.FileName;
            FileInfo fi = new FileInfo(fullName);
            string name = fi.Name;//获取名称
            string type = fi.Extension;//获取类型
            if (type != ".xlsx" && type != ".xls")
            {
                return "类型错误";
            }
            string uploadPath = Server.MapPath("\\UpdateFile");//图片保存到文件夹下
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            file.SaveAs(uploadPath + "\\" + name);//保存图片至该路径路径
            return "1";
            //上传图片
            //HttpFileCollectionBase files = Request.Files;
            //HttpPostedFileBase file = files["upImage"];
            //if (file == null) return "-1";

            //string fullName = file.FileName;
            //FileInfo fi = new FileInfo(fullName);
            //string name = fi.Name;//获取图片名称
            //string type = fi.Extension;//获取图片类型
            //if (type == ".jpg" || type == ".gif" || type == ".bmp" || type == ".png")
            //{
            //    string uploadPath = Server.MapPath("\\UpdateImage");//图片保存到文件夹下
            //    if (!Directory.Exists(uploadPath))
            //        Directory.CreateDirectory(uploadPath);
            //    file.SaveAs(uploadPath + "\\" + name);//保存图片至该路径路径
            //}

            //return "";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Chat()
        {
            ViewBag.ClientName = "用户-" + new Random().Next(10000, 99999);
            return View();
        }
    }
}