using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Bussiness
{
	public class ValidarDadosLinhaProduto : IStrategy
	{
		
		public ICollection<string> processar(EntidadeDominio lp)
		{
			LinhaProduto linhaPrdouto = (LinhaProduto)lp;
			ICollection<string> erro = new List<string>();
			if (linhaPrdouto.nome == null)
			{
				erro.Add("Nome da linha Inválido");
			}
			return erro;
		}
	}
}
