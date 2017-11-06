using FxSaude.Core.Domain.Data;

namespace FxSaude.Produto.Domain.EF6.Data
{
    public class ProductDataContextProvider : IDataContextProvider
    {
        private IDataContext _dataContext;

        public IDataContext GetDataContext()
        {
            return _dataContext ?? (_dataContext = new ProductDataContext("name=FxSaudeConnection"));
        }
    }
}
