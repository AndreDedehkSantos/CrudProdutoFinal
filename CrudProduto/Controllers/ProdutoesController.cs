using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudProduto.Models;
using CrudProduto.Bussiness.Services;
using CrudProduto.Models.ViewModels;
using CrudProduto.Controllers.Fachada;
using System.Numerics;
using System.Globalization;

namespace CrudProduto.Controllers
{
    public class ProdutoesController : Controller
    {
        private readonly CrudProdutoContext _context;

        public ProdutoesController(CrudProdutoContext context)
        {
            _context = context;
        }

        // GET: Produtoes
        public async Task<IActionResult> Index()
        {

            ProdutoFachada pFachada = new ProdutoFachada(_context);
            ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
            listaEnt = pFachada.Listar();
            ICollection<Produto> lista = new List<Produto>();
            foreach(EntidadeDominio item in listaEnt)
            {
                lista.Add((Produto)item);
            }
            ProdutoConsulta pConsulta = new ProdutoConsulta();
            pConsulta.status = false;
            ProdutoViewModel pViewModel = new ProdutoViewModel { listaProd = lista, produtoConsulta = pConsulta };
            return View(pViewModel);
        }

        public async Task<IActionResult> Index2(ICollection<Produto> produtos)
        {
            ProdutoConsulta pConsulta = new ProdutoConsulta();
            ProdutoViewModel pViewModel = new ProdutoViewModel { listaProd = produtos, produtoConsulta = pConsulta };
            return View(pViewModel);
        }

        // GET: Produtoes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            
            ProdutoFachada produtoFachada = new ProdutoFachada(_context);
            Produto p = produtoFachada.Consultar(id);
            LinhaProdutoFachada lpFachada = new LinhaProdutoFachada(_context);
            LinhaProduto lp = lpFachada.Consultar(p.linhaProdutoid);
            AcessorioOpcionalFachada acessorioOFachada = new AcessorioOpcionalFachada(_context);
            AcessorioBasicoFachada acessorioBFachada = new AcessorioBasicoFachada(_context);
            ICollection<AcessorioOpcional> listaAcessoriosO = new List<AcessorioOpcional>();
            listaAcessoriosO = acessorioOFachada.Consultar(p.id);
            ICollection<AcessorioBasico> listaAcessoriosB = new List<AcessorioBasico>();
            listaAcessoriosB = acessorioBFachada.Consultar(p.linhaProdutoid);
            ProdutoViewModel pVM = new ProdutoViewModel { produto = p, acessoriosO = listaAcessoriosO, acessoriosB = listaAcessoriosB, linha = lp };
            if (p == null)
            {
                return NotFound();
            }

            return View(pVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Consultar(ProdutoViewModel p)
        {
            Produto produto = new Produto();
            if (p == null)
            {
                return View("Index");
            }
            else
            {
                if(p.produtoConsulta.id != null)
                {
                    ICollection<Produto> unico = new List<Produto>();
                    int id = int.Parse(p.produtoConsulta.id);
                    ProdutoFachada pFachada2 = new ProdutoFachada(_context);
                    unico.Add(pFachada2.Consultar(id));
                    return View ("Index2", unico);
                }
                produto.nome = p.produtoConsulta.nome;
                if(p.produtoConsulta.valorCompra != null)
                {
                    produto.valorCompra = double.Parse(p.produtoConsulta.valorCompra);
                }
                else
                {
                    produto.valorCompra = 0;
                }
               
                if(p.produtoConsulta.dataCompra != null)
                {
                    DateTime datetime = DateTime.ParseExact(p.produtoConsulta.dataCompra, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    produto.dataCompra = datetime;
                }
                else
                {
                    DateTime datetime = DateTime.ParseExact("01/02/1000", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    produto.dataCompra = datetime;
                }
                produto.codigo = p.produtoConsulta.codigo;
                produto.comprador = p.produtoConsulta.comprador;
                produto.status = p.produtoConsulta.status;
            }
            ProdutoFachada pFachada = new ProdutoFachada(_context);
            ICollection<Produto> lista = pFachada.ConsultarProduto(produto);
            return View("Index2", lista);
        }

       

        // GET: Produtoes/Create
        public IActionResult Create()
        {
            LinhaProdutoFachada lpFachada = new LinhaProdutoFachada(_context);
            ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
            ICollection<LinhaProduto> lista = new List<LinhaProduto>();
            listaEnt = lpFachada.Listar();
            foreach(EntidadeDominio item in listaEnt)
            {
                lista.Add((LinhaProduto)item);
            }
            var linhas = lista;
            var viewModel = new ProdutoViewModel{ lp = linhas};
            return View(viewModel);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoVM)
        {
            if (ModelState.IsValid)
            {
                produtoVM.produto.status = true;
                ProdutoFachada produtoFachada = new ProdutoFachada(_context);
               
                FichaTecnicaFachada fichaFachada = new FichaTecnicaFachada(_context);
                ICollection<string> validacoes = produtoFachada.ValidarProduto(produtoVM.produto);
                if (produtoFachada.ConsultarExistencia(produtoVM.produto.codigo))
                {
                    validacoes.Add("Já existe um produto com esse código");
                    return View("Error", validacoes);
                }
                ICollection<string> validacoesFicha = fichaFachada.ValidarFicha(produtoVM.produto.fichaTecnica);
                foreach (string item in validacoesFicha)
                {
                    validacoes.Add(item);
                }
                if (validacoes.Count() == 0)
                {
                    UsuarioFachada uFachada = new UsuarioFachada(_context); 
                    Usuario usuario = uFachada.existe(produtoVM.usuario);
                    if (usuario != null)
                    {
                        produtoFachada.salvar(produtoVM.produto);
                        LogFachada lFachada = new LogFachada(_context);
                        string descricao = "Inserção do Produto: " + produtoVM.produto.nome + ", Id: " + produtoVM.produto.id;
                        Log log = lFachada.gerarLog(descricao, usuario.id, false, true, produtoVM.produto.ToString());
                        lFachada.salvar(log);
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
            return RedirectToAction(nameof(Index));
        }

        // GET: Produtoes/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            LinhaProdutoFachada lpFachada = new LinhaProdutoFachada(_context);
            ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
            ICollection<LinhaProduto> lista = new List<LinhaProduto>();
            listaEnt = lpFachada.Listar();
            foreach (EntidadeDominio item in listaEnt)
            {
                lista.Add((LinhaProduto)item);
            }
            var linhas = lista;

            ProdutoFachada produtoFachada = new ProdutoFachada(_context);
            int ID = (int)id;
            var p = produtoFachada.Consultar(ID);
            if (p == null)
            {
                return NotFound();
            }
            ProdutoViewModel pVM = new ProdutoViewModel { produto = p,  lp = linhas};
            return View(pVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar (ProdutoViewModel produtoVM)
        {
            ProdutoFachada produtoFachada = new ProdutoFachada(_context);
            ICollection<string> validacoes = produtoFachada.ValidarProduto(produtoVM.produto);
            if(validacoes.Count() == 0)
            {
                UsuarioFachada uFachada = new UsuarioFachada(_context);
                Usuario usuario = uFachada.existe(produtoVM.usuario);
                Log log = new Log();
                if (usuario != null)
                {
                    produtoFachada.alterar(produtoVM.produto);
                    LogFachada lFachada = new LogFachada(_context);
                    string descricao = "Alteração do Produto: " + produtoVM.produto.nome + ", Id: " + produtoVM.produto.id;
                    log = lFachada.gerarLog(descricao, usuario.id, false, true, produtoVM.produto.ToString());
                    
                }
                else
                {
                    validacoes.Add("Usuário não encontrado");
                    return View("Error", validacoes);
                }
                if(usuario != null)
                {
                    LogFachada lFachada = new LogFachada(_context);
                    lFachada.salvar(log);
                }
            }
            else
            {
                return View("Error", validacoes);
            }
            return RedirectToAction("Index");
        }

   
       public IActionResult EditFT(Produto p)
        {
            return RedirectToAction("Edit", "FichaTecnicas", p);
        }

    }
}
