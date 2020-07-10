using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Dal
{
    public class LogDal
    {
        private readonly CrudProdutoContext _context;

        public LogDal(CrudProdutoContext context)
        {
            _context = context;
        }

        public void Salvar(Log log)
        {
            _context.Add(log);
            _context.SaveChangesAsync();
        }

    }
}
