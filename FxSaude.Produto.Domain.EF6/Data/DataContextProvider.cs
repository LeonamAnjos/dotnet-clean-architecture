using FxSaude.Core.Domain;
using FxSaude.Core.Domain.Data;

namespace FxSaude.Produto.Domain.EF6.Data
{
    public class DataContextProvider : IDataContextProvider
    {
        private IDataContext _dataContext;

        public IDataContext GetDataContext()
        {
            return _dataContext ?? (_dataContext = new DataContext("name=FxSaudeConnection"));
        }
    }
}
