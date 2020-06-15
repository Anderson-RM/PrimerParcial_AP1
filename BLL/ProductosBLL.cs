using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

using PrimerParcial_AP1.DAL;
using PrimerParcial_AP1.Entidades;

namespace PrimerParcial_AP1.BLL
{
    public class ProductosBLL
    {
        public static bool Guardar(Productos productos)
        {
            if (!Existe(productos.ProductId))
                return insertar(productos);
            else
                return Modificar(productos);

        }


        private static bool Insertar(Productos productos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Productos.add(productos);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        public static bool Modificar(Productos productos)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(productos).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally;
            {
                contexto.Dispose();
            }
            return paso;
            }
        }


        public  static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var productos = contexto.Productos.Find(id);
                if (productos != null)
                {
                    contexto.Productos.Remove(productos);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        public static ProductosBLL Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos productos;
            try
            {
                productos = contexto.Productos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            rerurn productos;
        }


        public static List<Productos> GetList(Exception<Funch<Productos, bool>> criterio)
        {
            List<Productos> lista = new List<Productos>
        }
    }
}




















