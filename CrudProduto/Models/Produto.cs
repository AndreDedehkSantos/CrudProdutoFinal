using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudProduto.Models
{
	public class Produto : EntidadeDominio
	{
		[Display(Name = "Código")]
		public string codigo { get; set; }
		[Display(Name = "Nome")]
		public string nome { get; set; }
		[Display(Name = "Valor de Compra")]
		public double valorCompra { get; set; }
		[Display(Name = "Data da compra")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
		[DataType(DataType.Date)]
		public DateTime dataCompra { get; set; }
		[Display(Name = "Quantidade")]
		public int quantidade { get; set; }
		[Display(Name = "Comprador")]
		public string comprador { get; set; }
		[Display(Name = "Ativo")]
		public bool status { get; set; }
		public FichaTecnica fichaTecnica { get; set; }
		[Display(Name = "Linha do Produto")]
		public int linhaProdutoid { get; set; }


		public Produto()
		{

		}

		public Produto(string nome, double valorCompra, DateTime dataCompra, int quantidade, string comprador, bool status, FichaTecnica fichaTecnica)
		{
			this.nome = nome;
			this.valorCompra = valorCompra;
			this.dataCompra = dataCompra;
			this.quantidade = quantidade;
			this.comprador = comprador;
			this.status = status;
			this.fichaTecnica = fichaTecnica;
		}

        public override string ToString()
        {
			return "Id: " + this.id.ToString() + " Nome: " +  this.nome + " Valor da Compra: " + this.valorCompra.ToString() + " Quantidade: " + this.quantidade.ToString()
					+ " Data da Compra: " + this.dataCompra.ToString() + " Quantidade: " + this.quantidade.ToString()
					+ " Comprador: " + this.comprador + " Status: " + this.status.ToString() + " Linha de Produto Id: " + this.linhaProdutoid.ToString();
        }
    }
}
