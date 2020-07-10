using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Models.ViewModels
{
    public class UsuarioViewModel
    {
        [Display(Name = "Nome")]
        public string nome { get; set; }
        [Display(Name = "Senha")]
        public string senha1 { get; set; }
        [Display(Name = "Confirmar Senha")]
        public string senha2 { get; set; }
    }
}
