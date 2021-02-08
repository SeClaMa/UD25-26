using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace UD25.Models
{
    public class Articulos
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public int Fabricante_Id { get; set; }
        public Fabricantes Fabricante { get; set; }


    }
    }

