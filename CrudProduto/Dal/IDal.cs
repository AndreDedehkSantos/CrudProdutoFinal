using CrudProduto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Dal
{
    interface IDal
    {
        void Salvar(EntidadeDominio entidadeDominio);
        void Alterar(EntidadeDominio entidadeDominio);
        ICollection<EntidadeDominio> Listar ();
        void Inativar(int id);
    }
}
