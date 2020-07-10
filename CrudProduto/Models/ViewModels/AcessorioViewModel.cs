using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Models.ViewModels
{
    public class AcessorioViewModel
    {
        public AcessorioBasico acessorio { get; set; }

        public ICollection<LinhaProduto> linhas { get; set; } = new List<LinhaProduto>();

        public AcessorioOpcional acessorioO { get; set; }

        public ICollection<Produto> produtos { get; set; } = new List<Produto>();

        public Usuario usuario { get; set; }

    }
}
