using System.Data.Entity.Migrations;
using FxSaude.Produto.Domain.EF6.Data;
using FxSaude.Produto.Domain.Entities;

namespace FxSaude.Produto.Domain.EF6.Migrations.Seeds
{
    internal class UserSeed
    {
        public static void Execute(ProductDataContext context)
        {
            context.Users.AddOrUpdate(u => u.Id, 
                new User{ Id = 1, Nickname = "Adm", Name = "Administrator", Email = "adm@gmail.com"}, 
                new User{ Id = 2, Nickname = "Leonam", Name = "Leonam Anjos", Email = "leonam.ricardo@gmail.com"});
        }
    }
}