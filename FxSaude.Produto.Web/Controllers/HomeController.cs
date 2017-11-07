using System.Web.Mvc;
using FxSaude.Core.Domain.Patterns;

namespace FxSaude.Produto.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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
