using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace FxSaude.Produto.Domain.EF6.Data
{
    public class DataConfiguration : DbConfiguration
    {
        public DataConfiguration()
        {
            SetProviderServices(
                SqlProviderServices.ProviderInvariantName, 
                SqlProviderServices.Instance);
        }
    }
}
