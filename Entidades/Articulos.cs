using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrimerParcial_AP1.Entidades
{
    public class Articulos
    {
        [Key]
        public int ProductoId { get; set; }
        public int Descripcion { get; set; }
        public int Existencia { get; set; }
        public int Costo { get; set; }
        public int ValorInventario { get; set; }


    }
}
