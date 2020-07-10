using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Bussiness
{
	public interface IStrategy
	{
		ICollection<string> processar(EntidadeDominio entidadeDominio);
	}
}
