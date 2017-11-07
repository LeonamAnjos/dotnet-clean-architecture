using System.Configuration;
using FxSaude.Core.Domain.Data;

namespace FxSaude.Produto.Domain.EF6.Data
{
    public class ProductDataContextProvider : IDataContextProvider
    {
        private IDataContext _dataContext;

        public IDataContext GetDataContext()
        {
            return _dataContext ?? (_dataContext = NewDataContext());
        }

        private static ProductDataContext NewDataContext()
        {
            var env = ConfigurationManager.AppSettings["Environment"];
            if (string.IsNullOrEmpty(env))
                return new ProductDataContext();

            return new ProductDataContext($"name={env}");
        }
    }
}
