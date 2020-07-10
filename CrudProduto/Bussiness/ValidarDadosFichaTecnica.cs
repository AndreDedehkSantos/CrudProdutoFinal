using CrudProduto.Models;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Bussiness
{
	public class ValidarDadosFichaTecnica : IStrategy
	{
		public ICollection<string> processar(EntidadeDominio ft)
		{
			ICollection<string> erro = new List<string>();
			FichaTecnica fichaTecnica = (FichaTecnica)ft;

			if(fichaTecnica.descricao == null)
			{
				erro.Add("Descrição inválida");
			}
			if(fichaTecnica.componenteBasico == null)
			{
				erro.Add("Componente Básico Inválido");
			}
			if(fichaTecnica.componentePrimario == null)
			{
				erro.Add("Componente Primário Inválido");
			}
			if(fichaTecnica.componenteSecundario == null)
			{
				erro.Add("Componente Secundário Inválido");
			}
			if(fichaTecnica.categoria == null)
			{
				erro.Add("Categoria Inválido");
			}
			if(fichaTecnica.subCategoria == null)
			{
				erro.Add("Sub-categoria Inválida");
			}
			return erro;			
		}
	}
}
