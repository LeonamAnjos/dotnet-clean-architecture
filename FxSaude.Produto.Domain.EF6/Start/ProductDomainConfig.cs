using FxSaude.Produto.Domain.EF6.Patterns;
using FxSaude.Produto.Domain.Patterns;
using Unity;

namespace FxSaude.Produto.Domain.EF6.Start
{
    public class ProductDomainConfig
    {
        /// <summary>
        /// Registers the product domain types with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IProductUnitOfWork, ProductUnityOfWork>();
        }
    }
}
