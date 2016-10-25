using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FxSaude.Core.Domain
{
    public interface IDataContextProvider
    {
        IDataContext GetDataContext();
    }
}
