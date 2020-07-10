using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProduto.Bussiness;
using CrudProduto.Bussiness.Services;
using CrudProduto.Controllers.Fachada;
using CrudProduto.Dal;
using CrudProduto.Models;
using CrudProduto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

namespace CrudProduto.Controllers
{
	public class LinhaProdutoesController : Controller
	{
		private readonly CrudProdutoContext _context;

		public LinhaProdutoesController(CrudProdutoContext context)
		{
			_context = context;
		}


		public IActionResult Index()
		{
			return RedirectToAction("Index", "Produtoes");
		}

		[HttpGet]
		public IActionResult Create()
        {
			return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(LinhaViewModel linhaVM)
		{
			LinhaProdutoFachada lpFachada = new LinhaProdutoFachada(_context);
			ICollection<string> validacoes = new List<string>();
			validacoes = lpFachada.ValidarLinha(linhaVM.linha);
			if(validacoes.Count() == 0)
            {
				UsuarioFachada uFachada = new UsuarioFachada(_context);
				Usuario usuario = uFachada.existe(linhaVM.usuario);
				if (usuario != null)
				{
					lpFachada.salvar(linhaVM.linha);
					LogFachada lFachada = new LogFachada(_context);
					string descricao = "Inserção da Ficha Técnica: " + linhaVM.linha.nome + " Id: " + linhaVM.linha.id;
					Log log = lFachada.gerarLog(descricao, usuario.id, true, false, linhaVM.linha.ToString());
					lFachada.salvar(log);
					return RedirectToAction("Index", "Produtoes");
				}
                else
                {
					validacoes.Add("Usuário não encontrado");
					return View("Error", validacoes);
                }
				
			}
            else
            {
				return View("Error", validacoes);
            }
			
		}
	}
}
