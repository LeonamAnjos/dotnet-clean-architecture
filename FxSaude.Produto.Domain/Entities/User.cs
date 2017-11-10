using FxSaude.Core.Domain;

namespace FxSaude.Produto.Domain.Entities
{
    public class User : Entity
    {
        public string Nickname { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
