using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Bussiness
{
	public class ValidarDadosAcessorioBasico : IStrategy
	{
		public ICollection<string> processar(EntidadeDominio a)
		{
			ICollection<string> erro = new List<string>();
			AcessorioBasico acessorio = (AcessorioBasico)a;
			if(acessorio.nome == null)
			{
				erro.Add("Nome do Acessório Inválido");
			}
			if(acessorio.descricao == null)
			{
				erro.Add("Descrição Inválida");
			}
			if(acessorio.quantidade <= 0)
			{
				erro.Add("Quantidade Inválida");
			}
			if(acessorio.linhaprodutoId == 0)
            {
				erro.Add("Selecione uma Linha de Produtos");
            }
			return erro;
		}
	}
}
