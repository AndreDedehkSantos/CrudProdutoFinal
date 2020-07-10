using CrudProduto.Bussiness;
using CrudProduto.Dal;
using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Controllers.Fachada
{
	public class ProdutoFachada : IFachada
	{
		private readonly CrudProdutoContext _context;

		public ProdutoFachada(CrudProdutoContext context)
		{
			_context = context;
		}

		public void alterar(EntidadeDominio entidadeDominio)
		{
			ProdutoDal pDal = new ProdutoDal(_context);
			pDal.Alterar(entidadeDominio);
		}

		public ICollection<Produto> ConsultarProduto(Produto p)
        {
			ProdutoDal pDal = new ProdutoDal(_context);
			return pDal.ConsultarProduto(p);
        }

		public bool ConsultarExistencia(string codigo)
        {
			ProdutoDal pDAL = new ProdutoDal(_context);
			return pDAL.ConsultarExistencia(codigo);
		}

        public ICollection<EntidadeDominio> Listar()
        {
			ProdutoDal pDAL = new ProdutoDal(_context);
			ICollection<EntidadeDominio> lista = new List<EntidadeDominio>();
			lista = pDAL.Listar();
			return lista;
        }

        public void salvar(EntidadeDominio entidadeDominio)
		{
			ProdutoDal pDAL = new ProdutoDal(_context);
			pDAL.Salvar(entidadeDominio);
		}

		public Produto Consultar(int id)
		{
			ProdutoDal pDAL = new ProdutoDal(_context);
			return pDAL.Consultar(id);
		}
		public ICollection<string> ValidarProduto(Produto produto)
		{
			ValidarDadosProduto vProduto = new ValidarDadosProduto();
			ICollection<string> validacoes = vProduto.processar(produto);
			return validacoes;
		}
	}
}
