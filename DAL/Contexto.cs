using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace PrimerParcial_AP1.DAL
{
    public class Contexto : DbContext
    {
        /*public int MyProperty { get; set; }
        public int MyProperty { get; set; }
        public int MyProperty { get; set; }*/


        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseSqlite(@"Data Source= DATA\BasedeDatos.db");
        }
    }
}
