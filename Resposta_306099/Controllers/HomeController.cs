using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Resposta_306099.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public FileStreamResult DownloadImagem()
        {
            //Converter byte[] to Stream
            Stream streamImg = new MemoryStream(BuscarImagem());
            return File(streamImg, "image/png");
        }

        public FileContentResult DownloadImagem2()
        {
            return File(BuscarImagem(), "image/png");
        }

        private byte[] BuscarImagem()
        {
            WebClient wc = new WebClient();
            byte[] bytesImg = wc.DownloadData("https://cdn.sstatic.net/Sites/stackoverflow/company/img/logos/so/so-logo.png");
            return bytesImg;
        }
    }
}