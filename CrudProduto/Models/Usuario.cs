using System.ComponentModel.DataAnnotations;

namespace CrudProduto.Models
{
	public class Usuario : EntidadeDominio
	{
		[Display(Name = "Nome")]
		public string nome { get; set; }
		[Display(Name = "Senha")]
		public string senha { get; set; }


		public Usuario()
		{

		}
		public Usuario(string nome, string senha1, string senha)
		{
			this.nome = nome;
			this.senha = senha;;
		}
	}
}
