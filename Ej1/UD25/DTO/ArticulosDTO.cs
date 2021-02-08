using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UD25.DTO
{
    public class ArticulosDTO
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }

        public int Fabricante_Id { get; set; }
    }
}
