using FxSaude.Core.Domain;

namespace FxSaude.Produto.Domain.Entities
{
    public class Micropost : Entity
    {
        public string Content { get; set; }

        public User User { get; set; }
    }
}