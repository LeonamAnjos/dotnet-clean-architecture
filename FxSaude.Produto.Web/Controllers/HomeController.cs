﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using FxSaude.Core.Domain;
using FxSaude.Produto.Domain.Entidades;

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

            var repository = _unitOfWork.GetRepository<Empresa>();
            var empresas = repository.Queryable().ToList();

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
