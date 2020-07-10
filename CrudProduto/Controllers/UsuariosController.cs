using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudProduto.Models;
using CrudProduto.Models.ViewModels;
using CrudProduto.Controllers.Fachada;

namespace CrudProduto.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly CrudProdutoContext _context;

        public UsuariosController(CrudProdutoContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            UsuarioViewModel usuarioVM = new UsuarioViewModel();
            return View(usuarioVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioViewModel usuarioVM)
        { 
            UsuarioFachada uFachada = new UsuarioFachada(_context);
            ICollection<string> validacoes = uFachada.Validarusuario(usuarioVM.nome, usuarioVM.senha1, usuarioVM.senha2);
            if(validacoes.Count() == 0)
            {
                usuarioVM.senha1 = uFachada.cliptografar(usuarioVM.senha1);
                Usuario usuario = new Usuario { nome = usuarioVM.nome, senha = usuarioVM.senha1 };
                uFachada.Salvar(usuario);
                return RedirectToAction("Index", "Produtoes");
            }
            else
            {
                return View("Error", validacoes);
            }
        }
    }
}
