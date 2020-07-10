using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Dal
{
    public class AcessorioOpcionalDal
    {
        private readonly CrudProdutoContext _context;

        public AcessorioOpcionalDal(CrudProdutoContext context)
        {
            _context = context;
        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {

        }

        public void Inativar(int id)
        {
            
        }
        public ICollection<AcessorioOpcional> Consultar(int id)
        {
            return _context.AcessorioOpcional.Where(x => x.produtoId == id).ToList();
        }
        public ICollection<EntidadeDominio> Listar()
        {
            ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
            var lista = _context.AcessorioOpcional.ToList();
            foreach (Acessorio item in lista)
            {
                listaEnt.Add((EntidadeDominio)item);
            }
            return listaEnt;
        }

        public void Salvar(EntidadeDominio entidadeDominio)
        {
            AcessorioOpcional acessorio = (AcessorioOpcional)entidadeDominio;
            _context.Add<AcessorioOpcional>(acessorio);
            _context.SaveChanges();
        }
    }
}

