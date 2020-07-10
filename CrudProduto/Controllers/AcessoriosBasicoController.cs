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
    public class AcessoriosBasicoController : Controller
    {
        private readonly CrudProdutoContext _context;

        public AcessoriosBasicoController(CrudProdutoContext context)
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
            LinhaProdutoFachada lpFachada = new LinhaProdutoFachada(_context);
            ICollection<LinhaProduto> listaLinha = new List<LinhaProduto>();
            ICollection<EntidadeDominio> listaEnt = lpFachada.Listar();
            foreach(EntidadeDominio item in listaEnt)
            {
                listaLinha.Add((LinhaProduto)item);
            }
            var aVM = new AcessorioViewModel { linhas = listaLinha};
            return View(aVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AcessorioViewModel acessorioVM)
        {
            AcessorioBasicoFachada acessorioFachada = new AcessorioBasicoFachada(_context);
            ICollection<string> validacoes = new List<string>();
            validacoes = acessorioFachada.ValidarAcessorioBasico(acessorioVM.acessorio);
            if(validacoes.Count() == 0)
            {
                UsuarioFachada uFachada = new UsuarioFachada(_context);
                Usuario usuario = uFachada.existe(acessorioVM.usuario);
                if (usuario != null)
                {
                    acessorioFachada.salvar(acessorioVM.acessorio);
                    LogFachada lFachada = new LogFachada(_context);
                    string descricao = "Alteração da Ficha Técnica Id: " + acessorioVM.acessorio.id;
                    Log log = lFachada.gerarLog(descricao, usuario.id, true, false, acessorioVM.acessorio.ToString());
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
