using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Dal
{
    public class UsuarioDal
    {
        private readonly CrudProdutoContext _context;

        public UsuarioDal(CrudProdutoContext context)
        {
            _context = context;
        }

        public Usuario Existencia(Usuario usuario)
        {
            ICollection<Usuario> lista = _context.Usuario.ToList();
            foreach(Usuario item in lista)
            {
                if (item.nome.Equals(usuario.nome))
                {
                    return item;
                }
            }
            return null;
        }
        public void salvar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }
    }
}
