using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
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
            repository.Setup(r => r.Queryable()).Returns(_users.AsQueryable);

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
        public void ShouldReturnAllUsers()
        {
            _users.Add(new User { Id = 1, Nickname = "DI", Name = "Didi", Email = "didi@trapalhoes.com.br"});
            _users.Add(new User { Id = 2, Nickname = "DE", Name = "Dede", Email = "dede@trapalhoes.com.br"});
            _users.Add(new User { Id = 3, Nickname = "MU", Name = "Mussum", Email = "mussum@trapalhoes.com.br"});

            var expected = _users.Select(u => new UserViewModel { Name = u.Name, Nickname = u.Nickname, Email = u.Email }).ToList();
            var actual = _usersController.Get().ToList();
            
            Assert.That(actual.Count, Is.EqualTo(expected.Count));
            Assert.That(actual[0].Name, Is.EqualTo(expected[0].Name));
            Assert.That(actual[1].Name, Is.EqualTo(expected[1].Name));
            Assert.That(actual[2].Name, Is.EqualTo(expected[2].Name));
            Assert.That(actual[0].Nickname, Is.EqualTo(expected[0].Nickname));
            Assert.That(actual[1].Nickname, Is.EqualTo(expected[1].Nickname));
            Assert.That(actual[2].Nickname, Is.EqualTo(expected[2].Nickname));
            Assert.That(actual[0].Email, Is.EqualTo(expected[0].Email));
            Assert.That(actual[1].Email, Is.EqualTo(expected[1].Email));
            Assert.That(actual[2].Email, Is.EqualTo(expected[2].Email));
        }

        [Test]
        public void ShouldReturnUserWithSameId()
        {
            _users.Add(new User { Id = 1, Nickname = "Mili", Name = "Milena", Email = "milena@chiquititas.com.br" });
            _users.Add(new User { Id = 2, Nickname = "Pata", Name = "Patrícia", Email = "patricia@chiquititas.com.br" });
            _users.Add(new User { Id = 3, Nickname = "Bia", Name = "Beatriz", Email = "beatriz@chiquititas.com.br" });

            var actual = _usersController.Get(2);
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Nickname, Is.EqualTo("Pata"));
            Assert.That(actual.Name, Is.EqualTo("Patrícia"));
            Assert.That(actual.Email, Is.EqualTo("patricia@chiquititas.com.br"));
        }

        [Test]
        public void ShouldNotFindUser()
        {
            _users.Add(new User { Id = 1, Nickname = "Mili", Name = "Milena", Email = "milena@chiquititas.com.br" });
            Assert.That(() => _usersController.Get(2), Throws.Exception.TypeOf<KeyNotFoundException>());
        }

        [Test]
        public void ShouldUpdateUser()
        {
            _users.Add(new User { Id = 1, Nickname = "Mili", Name = "Milena", Email = "milena@chiquititas.com.br" });
            _users.Add(new User { Id = 2, Nickname = "Pata", Name = "Patrícia", Email = "patricia@chiquititas.com.br" });
            _users.Add(new User { Id = 3, Nickname = "Bia", Name = "Beatriz", Email = "beatriz@chiquititas.com.br" });

            _usersController.Put(2, new UserUpdateViewModel{ Nickname = "NewNick", Name = "New Name", Email = "new@user.com.br"});
            var actual = _users.FirstOrDefault(u => u.Id == 2);

            Assert.That(_users.Count, Is.EqualTo(3));
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual.Nickname, Is.EqualTo("NewNick"));
            Assert.That(actual.Name, Is.EqualTo("New Name"));
            Assert.That(actual.Email, Is.EqualTo("new@user.com.br"));
        }

        [Test]
        public void ShouldNotFindUserToUpdate()
        {
            _users.Add(new User { Id = 1, Nickname = "Mili", Name = "Milena", Email = "milena@chiquititas.com.br" });

            Assert.That(() => _usersController.Put(2, new UserUpdateViewModel { Nickname = "NewNick", Name = "New Name", Email = "new@user.com.br" }),
                Throws.Exception.TypeOf<KeyNotFoundException>());
        }

        [Test]
        [Ignore("Destroy (DELETE) /api/users/:id")]
        public void ShouldDeleteUserWithSameId()
        {
        }
        
    }

}
