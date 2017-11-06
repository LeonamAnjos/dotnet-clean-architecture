using System.Data.Entity;
using FxSaude.Core.Domain.Data;
using FxSaude.Produto.Domain.Entidades;

namespace FxSaude.Produto.Domain.EF6.Data
{
    public class ProductDataContext : DbContext, IDataContext 
    {
        public ProductDataContext(string nameOrConnectionString) : base(nameOrConnectionString) {}

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
