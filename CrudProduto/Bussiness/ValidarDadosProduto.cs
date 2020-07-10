using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Bussiness
{
	public class ValidarDadosProduto : IStrategy
	{
		public ICollection<string> processar(EntidadeDominio p)
		{
			Produto produto = (Produto) p;
			ICollection<string> erro = new List<string>();
			if(produto.nome == null)
			{
				erro.Add("Nome do Porduto Inválido");
			}
			if(produto.quantidade <= 0)
			{
				erro.Add("Quantidade Inválida");
			}
			if (produto.dataCompra == null)
			{
				erro.Add("Data da compra Inválida");
			}
			if(produto.comprador == null)
			{
				erro.Add("Comprador do Porduto Inválido");
			}
			if(produto.valorCompra <= 0.0)
			{
				erro.Add("Valor da compra do Porduto Inválido");
			}
			if(produto.linhaProdutoid == 0)
			{
				erro.Add("Selecione uma Linha de Produtos");
			}
			return erro;
		}
	}
}
