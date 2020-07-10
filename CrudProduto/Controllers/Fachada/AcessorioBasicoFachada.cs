using CrudProduto.Bussiness;
using CrudProduto.Dal;
using CrudProduto.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Controllers.Fachada
{
    public class AcessorioBasicoFachada : IFachada
    {

        private readonly CrudProdutoContext _context;

        public AcessorioBasicoFachada(CrudProdutoContext context)
        {
            _context = context;
        }

        public void alterar(EntidadeDominio entidadeDominio)
        {
            
        }
        public ICollection<AcessorioBasico> Consultar(int id)
        {
            AcessorioBasicoDal aDal = new AcessorioBasicoDal(_context);
            return aDal.Consultar(id);
        }

        public ICollection<EntidadeDominio> Listar()
        {
            return null;
        }

        public void salvar(EntidadeDominio entidadeDominio)
        {
            AcessorioBasicoDal aDal = new AcessorioBasicoDal(_context);
            aDal.Salvar(entidadeDominio);
        }

        public ICollection<string> ValidarAcessorioBasico(Acessorio acessorio)
        {
            ValidarDadosAcessorioBasico vAcessorio = new ValidarDadosAcessorioBasico();
            ICollection<string> validacoes = vAcessorio.processar(acessorio);
            return validacoes;
        }

    }
}
