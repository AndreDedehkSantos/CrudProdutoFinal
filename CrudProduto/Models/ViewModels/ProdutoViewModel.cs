using CrudProduto.Bussiness.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Models.ViewModels
{
	public class ProdutoViewModel
	{
		public Produto produto { get; set; }
		public ICollection<Produto> listaProd { get; set; }
        public ProdutoConsulta produtoConsulta { get; set; }
        public LinhaProduto linha { get; set; }

		public ICollection<AcessorioBasico> acessoriosB = new List<AcessorioBasico>();

		public ICollection<AcessorioOpcional> acessoriosO = new List<AcessorioOpcional>();

		public ICollection<LinhaProduto> lp { get; set; }

		public Usuario usuario { get; set; }
	}
}
