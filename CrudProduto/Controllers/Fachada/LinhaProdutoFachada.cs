using CrudProduto.Bussiness;
using CrudProduto.Bussiness.Services;
using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Controllers.Fachada
{
	public class LinhaProdutoFachada : IFachada
	{
		private readonly CrudProdutoContext _context;

		public LinhaProdutoFachada(CrudProdutoContext context)
		{
			_context = context;
		}

		public void alterar(EntidadeDominio entidadeDominio)
		{
			
		}

		public LinhaProduto Consultar(int id)
		{
			LinhaProdutoDal pDAL = new LinhaProdutoDal(_context);
			return pDAL.Consultar(id);
		}

		public ICollection<EntidadeDominio> Listar()
		{
			LinhaProdutoDal lpDal = new LinhaProdutoDal(_context);
			ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
			listaEnt = lpDal.Listar();
			return listaEnt;
		}

		public void salvar(EntidadeDominio entidadeDominio)
		{
			LinhaProdutoDal lpDal = new LinhaProdutoDal(_context);
			lpDal.Salvar(entidadeDominio);
		}

		public ICollection<string> ValidarLinha(LinhaProduto linhaProduto)
		{
			ValidarDadosLinhaProduto vLinha = new ValidarDadosLinhaProduto();
			ICollection<string> validacoes = vLinha.processar(linhaProduto);
			return validacoes;
		}
	}
}
