using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Models
{
    public class AcessorioOpcional:Acessorio
    {
        [Display(Name = "Produto")]
        public int produtoId { get; set; }

        public override string ToString()
        {
            return "Id: " + this.id.ToString() + " Nome: " + this.nome + " Descrição: " + this.descricao + " Quantidade: " + this.quantidade + " Produto Id: " + this.produtoId;
        }
    }
    

}
         