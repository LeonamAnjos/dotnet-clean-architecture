using FxSaude.Core.Domain;

namespace FxSaude.Produto.Domain.Entidades
{
    public class Empresa : Entidade
    {
        public string Nome { get; set; }

        public string Cnpj { get; set; }

        public string Logo { get; set; }
    }
}