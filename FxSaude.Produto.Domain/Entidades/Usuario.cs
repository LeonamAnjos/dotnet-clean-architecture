using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FxSaude.Core.Domain;

namespace FxSaude.Produto.Domain.Entidades
{
    public class Usuario : Entidade
    {
        public string Apelido { get; set; }

        public string Nome { get; set; }

        public Empresa Empresa { get; set; }

    }
}
