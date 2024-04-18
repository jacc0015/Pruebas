using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmueblesCrud.BusinessEntities.Models
{
    public class TipoInmueble
    {

        [Key]
        public int TipoInmuebleId { get; set; }
        public string Descripcion { get; set; }
    }
}
