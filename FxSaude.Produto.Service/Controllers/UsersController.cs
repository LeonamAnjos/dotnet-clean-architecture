using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FxSaude.Produto.Domain.Entities;
using FxSaude.Produto.Domain.Patterns;
using FxSaude.Produto.Service.Models.Users;

namespace FxSaude.Produto.Service.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IProductUnitOfWork _productUnitOfWork;

        public UsersController(IProductUnitOfWork productProductUnitOfWork)
        {
            _productUnitOfWork = productProductUnitOfWork;
        }

        // GET: api/User
        public IEnumerable<UserViewModel> Get()
        {
            var repository = _productUnitOfWork.GetRepository<User>();
            return repository.Queryable().Select(u => new UserViewModel
            {
                Nickname = u.Nickname,
                Name = u.Name,
                Email = u.Email
            });
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]UserCreateViewModel value)
        {
            var user = new User {Name = value.Name, Email = value.Email};
            var repository = _productUnitOfWork.GetRepository<User>();
            repository.Insert(user);
            _productUnitOfWork.SaveChanges();
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
