using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Models
{
    public class ProdutoConsulta
    {
		[Display(Name = "Código")]
        public string codigo { get; set; }
        public string id { get; set; }
		[Display(Name = "Nome")]
		public string nome { get; set; }
		[Display(Name = "Valor de Compra")]
		public string valorCompra { get; set; }
		[Display(Name = "Data da compra")]
		public string dataCompra { get; set; }
		[Display(Name = "Quantidade")]
		public string quantidade { get; set; }
		[Display(Name = "Comprador")]
		public string comprador { get; set; }
		[Display(Name = "Ativo")]
		public bool status { get; set; }
	}
}
