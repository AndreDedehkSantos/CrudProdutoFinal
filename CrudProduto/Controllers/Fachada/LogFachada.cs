using CrudProduto.Bussiness;
using CrudProduto.Dal;
using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Controllers.Fachada
{
    public class LogFachada
    {
        private readonly CrudProdutoContext _context;

        public LogFachada(CrudProdutoContext context)
        {
            _context = context;
        }

        public void salvar(Log log)
        {
            LogDal lDal = new LogDal(_context);
            lDal.Salvar(log);
        }

        public Log gerarLog(string descricao, int usuarioId, bool alt, bool ins, string manter)
        {
            GerarLog gLog = new GerarLog();
            return gLog.Processar(descricao, usuarioId, alt, ins, manter);
        }
    }
}
