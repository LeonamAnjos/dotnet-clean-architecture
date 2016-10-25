using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FxSaude.Core.Domain;
using FxSaude.Produto.Domain.Entidades;

namespace FxSaude.Produto.Domain.EF6
{
    public class DataContext : DbContext, IDataContext 
    {
        public DataContext(string nameOrConnectionString) : base(nameOrConnectionString) {}

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
