using System.Data.Entity;
using FxSaude.Core.Domain;
using FxSaude.Core.Domain.Data;
using FxSaude.Produto.Domain.Entidades;

namespace FxSaude.Produto.Domain.EF6.Data
{
    public class DataContext : DbContext, IDataContext 
    {
        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString) {}

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
