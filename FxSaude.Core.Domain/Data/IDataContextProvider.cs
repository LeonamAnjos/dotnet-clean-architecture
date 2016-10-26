namespace FxSaude.Core.Domain.Data
{
    public interface IDataContextProvider
    {
        IDataContext GetDataContext();
    }
}
