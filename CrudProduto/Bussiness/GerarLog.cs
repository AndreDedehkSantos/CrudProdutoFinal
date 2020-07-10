using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Bussiness
{
	public class GerarLog 
	{
		public Log Processar(string desc, int usuId, bool alt, bool ins, string m)
		{
			DateTime dthora = DateTime.Now;
			return new Log { descricao = desc, idUsuario = usuId, alteraco = alt, insercao = ins, dataHora = dthora, manter = m };

		}
	}
}
