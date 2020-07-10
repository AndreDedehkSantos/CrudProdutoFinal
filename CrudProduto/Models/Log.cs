using System;

namespace CrudProduto.Models
{
	public class Log 
	{
		public int id { get; set; }
		public DateTime dataHora { get; set; }
		public int idUsuario { get; set; }
		public string descricao { get; set; }

		public string manter { get; set; }
		public bool insercao { get; set; }
		public bool alteraco { get; set; }

		public Log()
		{

		}
        public Log(DateTime dataHora, int idUsuario, string descricao, string manter, bool insercao, bool alteraco)
        {
            this.dataHora = dataHora;
            this.idUsuario = idUsuario;
            this.descricao = descricao;
			this.manter = manter;
            this.insercao = insercao;
            this.alteraco = alteraco;
        }
    }
}
