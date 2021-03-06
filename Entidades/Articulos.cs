﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrimerParcial_AP1.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }

        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public double Costo { get; set; }
        public double ValorInventario { get; set; }        

        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = "";
            Existencia = 0;
            Costo = 0;
            ValorInventario = 0;
        }
    }
}
