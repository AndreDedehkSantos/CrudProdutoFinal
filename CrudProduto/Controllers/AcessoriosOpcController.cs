using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProduto.Controllers.Fachada;
using CrudProduto.Models;
using CrudProduto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CrudProduto.Controllers
{

    public class AcessoriosOpcController : Controller
    {

        private readonly CrudProdutoContext _context;

        public AcessoriosOpcController(CrudProdutoContext context)
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
            ProdutoFachada pFachada = new ProdutoFachada(_context);
            ICollection<Produto> listaProduto = new List<Produto>();
            ICollection<EntidadeDominio> listaEnt = pFachada.Listar();
            foreach (EntidadeDominio item in listaEnt)
            {
                listaProduto.Add((Produto)item);
            }
            var aVM = new AcessorioViewModel { produtos = listaProduto };
            return View(aVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AcessorioViewModel acessorioVM)
        {
            AcessorioOpcionalFachada acessorioFachada = new AcessorioOpcionalFachada(_context);
            ICollection<string> validacoes = new List<string>();
            validacoes = acessorioFachada.ValidarAcessorioOpcional(acessorioVM.acessorioO);
            if (validacoes.Count() == 0)
            {
                UsuarioFachada uFachada = new UsuarioFachada(_context);
                Usuario usuario = uFachada.existe(acessorioVM.usuario);
                if (usuario != null)
                {
                    acessorioFachada.salvar(acessorioVM.acessorioO);
                    LogFachada lFachada = new LogFachada(_context);
                    string descricao = "Inserção do Acessório Opcional: " + " Id: " + acessorioVM.acessorioO.nome + acessorioVM.acessorioO.id;
                    Log log = lFachada.gerarLog(descricao, usuario.id, true, false, acessorioVM.acessorioO.ToString());
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
