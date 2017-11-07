using System.Web.Mvc;
using FxSaude.Core.Domain.Data;
using FxSaude.Core.Domain.Patterns;
using FxSaude.Produto.Domain.EF6.Data;
using FxSaude.Produto.Domain.EF6.Patterns;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace FxSaude.Produto.Web
{
    public class InversionOfControlConfig
    {
        public static void RegisterDependencies()
        {
            var container = new UnityContainer();
            container.RegisterType<IDataContextProvider, ProductDataContextProvider>();
            container.RegisterType<IUnitOfWork, ProductUnityOfWork>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
