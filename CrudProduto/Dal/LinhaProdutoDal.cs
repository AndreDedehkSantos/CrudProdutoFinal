using CrudProduto.Dal;
using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Bussiness.Services
{
	public class LinhaProdutoDal:IDal
	{
		private readonly CrudProdutoContext _context;
		

		public LinhaProdutoDal(CrudProdutoContext context)
		{
			_context = context;
		}

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            
        }

        public void Inativar(int id)
        {
            
        }
		public LinhaProduto Consultar(int id)
		{
			return _context.LinhaProduto.Find(id);
		}

		public ICollection<EntidadeDominio> Listar()
		{
			ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
			var lista = _context.LinhaProduto.ToList();
			foreach (LinhaProduto item in lista)
			{
				listaEnt.Add((EntidadeDominio)item);
			}
			return listaEnt;
		}

		public void Salvar(EntidadeDominio entidadeDominio)
		{
			LinhaProduto linha = (LinhaProduto)entidadeDominio;
			_context.Add(linha);
			_context.SaveChanges();
		}


    }
}
