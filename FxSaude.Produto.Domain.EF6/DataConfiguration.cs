using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace FxSaude.Produto.Domain.EF6
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
