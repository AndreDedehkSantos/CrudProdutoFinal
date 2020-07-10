using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProduto.Models
{
    public class EntidadeDominio
    {
        [Display(Name = "Código")]
        public int id { get; set; }

        public EntidadeDominio()
        {

        }
        public EntidadeDominio(int id)
        {
            this.id = id;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
