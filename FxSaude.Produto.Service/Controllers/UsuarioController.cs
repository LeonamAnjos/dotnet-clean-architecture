using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FxSaude.Core.Domain.Patterns;
using FxSaude.Produto.Domain.EF6.Data;
using FxSaude.Produto.Domain.EF6.Patterns;
using FxSaude.Produto.Domain.Entidades;
using FxSaude.Produto.Domain.Patterns;

namespace FxSaude.Produto.Service.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IProductUnitOfWork _productUnitOfWork;

        public UsuarioController(IProductUnitOfWork productProductUnitOfWork)
        {
            _productUnitOfWork = productProductUnitOfWork;
        }

        // GET: api/Usuario
        public IEnumerable<string> Get()
        {
            var repository = _productUnitOfWork.GetRepository<Usuario>();
            return repository.Queryable().Select(u => u.Nome);
//            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Usuario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {
        }
    }
}
