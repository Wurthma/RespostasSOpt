using Resposta_304817.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resposta_304817.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult MeuSelectList()
        {
            Exemplo exemplo = new Exemplo();
            //Monta a lista com as opções do dropdown
            exemplo.Tipo_user = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "Selecione" },
                new SelectListItem { Value = "1", Text = "Administrador" },
                new SelectListItem { Value = "2", Text = "Bibliotecário" },
                new SelectListItem { Value = "3", Text = "Professor" },
                new SelectListItem { Value = "4", Text = "Aluno" }
            };

            return View(exemplo);
        }
    }
}