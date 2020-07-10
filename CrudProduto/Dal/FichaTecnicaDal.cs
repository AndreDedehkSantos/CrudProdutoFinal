using CrudProduto.Models;
using Remotion.Linq.Clauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Dal
{
    public class FichaTecnicaDal : IDal
    {
        private readonly CrudProdutoContext _context;

        public FichaTecnicaDal(CrudProdutoContext context)
        {
            _context = context;
        }
        public void Alterar(EntidadeDominio entidadeDominio)
        {
            FichaTecnica ficha = (FichaTecnica)entidadeDominio;
            _context.Update(ficha);
            _context.SaveChangesAsync();
        }

        public void Inativar(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<EntidadeDominio> Listar()
        {
            throw new NotImplementedException();
        }

        public FichaTecnica find(int id)
        {
            return _context.FichaTecnica.Find(id);
        }

        public void Salvar(EntidadeDominio entidadeDominio)
        {
            FichaTecnica ficha = (FichaTecnica)entidadeDominio;
            _context.FichaTecnica.Add(ficha);
        }
    }
}
