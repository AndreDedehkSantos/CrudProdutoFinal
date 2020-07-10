using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudProduto.Models;

namespace CrudProduto.Models
{
    public class CrudProdutoContext : DbContext
    {
        public CrudProdutoContext (DbContextOptions<CrudProdutoContext> options)
            : base(options)
        {
        }

        public DbSet<AcessorioBasico> AcessorioBasico { get; set; }

        public DbSet<AcessorioOpcional> AcessorioOpcional { get; set; }

        public DbSet<FichaTecnica> FichaTecnica { get; set; }

        public DbSet<LinhaProduto> LinhaProduto { get; set; }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Log> Log { get; set; }


    }
}
