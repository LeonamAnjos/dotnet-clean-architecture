using System.Data.Entity;
using FxSaude.Core.Domain.Data;
using FxSaude.Produto.Domain.Entities;

namespace FxSaude.Produto.Domain.EF6.Data
{
    public class ProductDataContext : DbContext, IDataContext 
    {
        public ProductDataContext() {}
        public ProductDataContext(string nameOrConnectionString) : base(nameOrConnectionString) {}

        public DbSet<Micropost> Microposts { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
