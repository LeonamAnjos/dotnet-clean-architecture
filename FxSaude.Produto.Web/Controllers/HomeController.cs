using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FxSaude.Produto.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Operadora()
        {
            ViewBag.Title = "Operadoras";

            return View();
        }

        public ActionResult Produto()
        {
            ViewBag.Title = "Produtos";

            return View();
        }

        public ActionResult Plano()
        {
            ViewBag.Title = "Planos";

            return View();
        }
    }
}
