using CrudProduto.Models;
using Microsoft.AspNetCore.JsonPatch.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CrudProduto.Dal
{
	public class ProdutoDal : IDal
	{
		private readonly CrudProdutoContext _context;

		public ProdutoDal(CrudProdutoContext context)
		{
			_context = context;
		}

        public bool ConsultarExistencia(string codigo)
        {
            var resultado = _context.Produto.Where(x => x.codigo == codigo).FirstOrDefault();
            if(resultado != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            Produto produto = (Produto)entidadeDominio;
            _context.Update(produto);
            _context.SaveChangesAsync();
        }

        public void Inativar(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Produto> ConsultarProduto(Produto p)
        {
            HashSet<Produto> consulta = new HashSet<Produto>();

            if(p.codigo != null)
            {
                Produto resultado = _context.Produto.FirstOrDefault(x => x.codigo == p.codigo);
                consulta.Add(resultado);
            }

            if(p.comprador != null)
            {
                var resultado = _context.Produto.Where(x => x.comprador == p.comprador).ToList();
                foreach (Produto item in resultado)
                {
                    consulta.Add(item);
                }
            }

            if (p.status)
            {
                var resultado = _context.Produto.Where(x => x.status == true).ToList();
                foreach (Produto item in resultado)
                {
                    consulta.Add(item);
                }
            }
            else
            {
                var resultado = _context.Produto.Where(x => x.status == false).ToList();
                foreach (Produto item in resultado)
                {
                    consulta.Add(item);
                }

            }

            if(p.quantidade != 0)
            {
                var resultado = _context.Produto.Where(x => x.valorCompra == p.valorCompra).ToList();
                foreach (Produto item in resultado)
                {
                    consulta.Add(item);
                }
            }

            if(p.valorCompra != 0.0)
            {
                var resultado = _context.Produto.Where(x => x.valorCompra == p.valorCompra).ToList();
                foreach (Produto item in resultado)
                {
                    consulta.Add(item);
                }
            }


            if(p.dataCompra != null)
            {
                var resultado = _context.Produto.Where(x => x.dataCompra == p.dataCompra).ToList();
                foreach (Produto item in resultado)
                {
                    consulta.Add(item);
                }
            }

            if (p.nome != null)
            {
                var resultado = _context.Produto.Where(x => x.nome == p.nome).ToList();
                foreach(Produto item in resultado)
                {
                    consulta.Add(item);
                }
            }

            return consulta;
        }

        public ICollection<EntidadeDominio> Listar()
        {
            ICollection<EntidadeDominio> listaEnt = new List<EntidadeDominio>();
            ICollection<Produto> lista = _context.Produto.ToList();
            foreach(Produto item in lista)
            {
                listaEnt.Add((EntidadeDominio)item);
            }
            return listaEnt;
        }
        
        public Produto Consultar(int id)
        {
             return _context.Produto.Include(Obj => Obj.fichaTecnica).FirstOrDefault(Obj => Obj.id == id); 
        }

        public void Salvar(EntidadeDominio entidadeDominio)
		{
            Produto produto = (Produto)entidadeDominio;
			_context.Produto.Add(produto);
			_context.SaveChanges();
		}
    }
}
