using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Controllers.Fachada
{
	interface IFachada
	{
		void salvar(EntidadeDominio entidadeDominio);
		void alterar(EntidadeDominio entidadeDominio);
		ICollection<EntidadeDominio> Listar();
	}
}
