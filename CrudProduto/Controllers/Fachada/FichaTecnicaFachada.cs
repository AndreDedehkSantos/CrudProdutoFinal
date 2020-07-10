using CrudProduto.Bussiness;
using CrudProduto.Dal;
using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Controllers.Fachada
{
    public class FichaTecnicaFachada : IFachada
    {
        private readonly CrudProdutoContext _context;

        public FichaTecnicaFachada(CrudProdutoContext context)
        {
            _context = context;
        }

        public void alterar(EntidadeDominio entidadeDominio)
        {
            FichaTecnicaDal fichaDal = new FichaTecnicaDal(_context);
            fichaDal.Alterar(entidadeDominio);
        }
        public FichaTecnica find(int id)
        {
            FichaTecnicaDal fDal = new FichaTecnicaDal(_context);
            return fDal.find(id);

        }

        public ICollection<EntidadeDominio> Listar()
        {
            return null;
        }

        public void salvar(EntidadeDominio entidadeDominio)
        {
            FichaTecnicaDal fDal = new FichaTecnicaDal(_context);
            fDal.Salvar(entidadeDominio);
        }

        public ICollection<string> ValidarFicha(FichaTecnica fichaTecnica)
        {
            ValidarDadosFichaTecnica vFicha = new ValidarDadosFichaTecnica();
            ICollection<string> validacoes = vFicha.processar(fichaTecnica);
            return validacoes;
        }
    }
}
