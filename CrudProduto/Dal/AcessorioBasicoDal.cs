using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProduto.Dal;

namespace CrudProduto.Dal
{
    public class AcessorioBasicoDal : IDal
    {
        private readonly CrudProdutoContext _context;

        public AcessorioBasicoDal(CrudProdutoContext context)
        {
            _context = context;
        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
           
        }

        public void Inativar(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<AcessorioBasico> Consultar (int id)
        {
            return _context.AcessorioBasico.Where(x => x.linhaprodutoId == id).ToList();
        }

        public ICollection<EntidadeDominio> Listar()
        {
            ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
            var lista = _context.AcessorioBasico.ToList();
            foreach (Acessorio item in lista)
            {
                listaEnt.Add((EntidadeDominio)item);
            }
            return listaEnt;
        }

        public void Salvar(EntidadeDominio entidadeDominio)
        {
            AcessorioBasico acessorio = (AcessorioBasico)entidadeDominio;
            _context.Add<AcessorioBasico>(acessorio);
            _context.SaveChanges();
        }
    }
}
