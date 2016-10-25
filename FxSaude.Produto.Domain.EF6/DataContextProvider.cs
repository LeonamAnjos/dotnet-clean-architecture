using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FxSaude.Core.Domain;

namespace FxSaude.Produto.Domain.EF6
{
    public class DataContextProvider : IDataContextProvider
    {
        private IDataContext _dataContext;

        public IDataContext GetDataContext()
        {
            return _dataContext ?? (_dataContext = new DataContext("FxSaudeDB"));
        }
    }
}
