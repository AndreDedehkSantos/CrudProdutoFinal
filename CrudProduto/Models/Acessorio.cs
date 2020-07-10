using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Models
{
	public abstract class Acessorio : EntidadeDominio
	{
		[Display(Name = "Nome")]
		public string nome { get; set; }
		[Display(Name = "Descrição")]
		public string descricao { get; set; }
		[Display(Name = "Quantidade")]
		public int quantidade { get; set; }


        public Acessorio()
		{

		}

		public Acessorio(string nome, string descricao, int quantidade)
		{
			this.nome = nome;
			this.descricao = descricao;
			this.quantidade = quantidade;
		}
	}
}
