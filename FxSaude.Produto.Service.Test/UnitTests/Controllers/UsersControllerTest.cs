using System.Collections.Generic;
using FxSaude.Core.Domain.Patterns;
using FxSaude.Produto.Domain.Entities;
using FxSaude.Produto.Domain.Patterns;
using FxSaude.Produto.Service.Controllers;
using FxSaude.Produto.Service.Models.Users;
using Moq;
using NUnit.Framework;

namespace FxSaude.Produto.Service.Test.UnitTests.Controllers
{
    [TestFixture]
    public class UsersControllerTest
    {
        private List<User> _users;
        private UsersController _usersController;

        [SetUp]
        public void Setup()
        {
            _users = new List<User>();

            var repository = new Mock<IRepository<User>>();
            repository.Setup(r => r.Insert(It.IsAny<User>())).Callback((User u) => _users.Add(u));

            var unitOfWork = new Mock<IProductUnitOfWork>();
            unitOfWork.Setup(u => u.GetRepository<User>()).Returns(repository.Object);

            _usersController = new UsersController(unitOfWork.Object);
        }

        [Test]
        public void ShouldCreateUser()
        {
            _usersController.Post(new UserCreateViewModel{ Name = "Donald Trump", Email = "trump@whitehouse.gov" });

            Assert.AreEqual(_users.Count, 1);
            Assert.AreEqual(_users[0].Name, "Donald Trump");
            Assert.AreEqual(_users[0].Email, "trump@whitehouse.gov");
        }

        [Test]
        public void ShouldCreateTwoUsers()
        {
            _usersController.Post(new UserCreateViewModel{ Name = "Donald Trump", Email = "trump@whitehouse.gov" });
            _usersController.Post(new UserCreateViewModel{ Name = "Hillary Clinton", Email = "hclinton@senate.gov" });

            Assert.That(_users.Count, Is.EqualTo(2));
            Assert.That(_users[0].Name, Is.EqualTo("Donald Trump"));
            Assert.That(_users[0].Email, Is.EqualTo("trump@whitehouse.gov"));
            Assert.That(_users[1].Name, Is.EqualTo("Hillary Clinton"));
            Assert.That(_users[1].Email, Is.EqualTo("hclinton@senate.gov"));
        }

        [Test]
        [Ignore("Index   (GET)    /api/users")]
        public void ShouldReturnAllUsers()
        {
        }

        [Test]
        [Ignore("Show    (GET)    /api/users/:id")]
        public void ShouldReturnUserWithSameId()
        {
        }

        [Test]
        [Ignore("Update  (PUT)    /api/users/:id")]
        public void ShouldUpdateUser()
        {
        }

        [Test]
        [Ignore("Destroy (DELETE) /api/users/:id")]
        public void ShouldDeleteUserWithSameId()
        {
        }
        
    }
}
