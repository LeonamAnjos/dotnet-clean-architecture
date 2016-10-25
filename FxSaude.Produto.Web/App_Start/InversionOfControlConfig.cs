using System.Web.Mvc;
using FxSaude.Core.Domain;
using FxSaude.Produto.Domain.EF6;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace FxSaude.Produto.Web
{
    public class InversionOfControlConfig
    {
        public static void RegisterDependencies()
        {
            var container = new UnityContainer();
            container.RegisterType<IDataContextProvider, DataContextProvider>();
            container.RegisterType<IUnitOfWork, UnityOfWork>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}