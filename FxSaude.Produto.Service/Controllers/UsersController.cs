using System;
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
                Id = u.Id,
                Nickname = u.Nickname,
                Name = u.Name,
                Email = u.Email
            });
        }

        // GET: api/User/5
        public UserViewModel Get(long id)
        {
            var repository = _productUnitOfWork.GetRepository<User>();
            var user = repository.Queryable().FirstOrDefault(u => u.Id == id);
            if (user == null)
                throw new KeyNotFoundException();
        
            return new UserViewModel
            {
                Id = user.Id,
                Nickname = user.Nickname,
                Name = user.Name,
                Email = user.Email,
            };
        }

        // POST: api/User
        public void Post([FromBody]UserCreateViewModel viewModel)
        {
            if(viewModel == null)
                throw new ArgumentNullException(nameof(viewModel)); 

            var user = new User {Nickname = viewModel.Nickname, Name = viewModel.Name, Email = viewModel.Email};
            var repository = _productUnitOfWork.GetRepository<User>();
            repository.Insert(user);
            _productUnitOfWork.SaveChanges();
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]UserUpdateViewModel value)
        {
            var repository = _productUnitOfWork.GetRepository<User>();
            var user = repository.Queryable().FirstOrDefault(u => u.Id == id);
            if (user == null)
                throw new KeyNotFoundException();

            user.Nickname = value.Nickname;
            user.Name = value.Name;
            user.Email = value.Email;
            _productUnitOfWork.SaveChanges();
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            var repository = _productUnitOfWork.GetRepository<User>();
            if(!repository.Queryable().Any(u => u.Id == id))
                throw new KeyNotFoundException();

            repository.Delete(id);
            _productUnitOfWork.SaveChanges();
        }
    }
}
