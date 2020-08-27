using Microsoft.EntityFrameworkCore;
using TCBlazor.DAL;
using TCBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace TCBlazor.BLL
{
   public class NacionalidadesBLL
    {
        public static bool Guardar(Nacionalidades nacionalidad)
        {
            if (!Existe(nacionalidad.NacionalidadId))
            {
               return Insertar(nacionalidad);
            }
            else
            {
               return Modificar(nacionalidad);
            }

          
        }

        private static bool Insertar(Nacionalidades nacionalidad)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Nacionalidades.Add(nacionalidad);
                paso = (contexto.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Nacionalidades nacionalidad)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(nacionalidad).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Nacionalidades.Any(d => d.NacionalidadId == id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
    

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var eliminar = contexto.Nacionalidades.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;
                paso = (contexto.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Nacionalidades Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Nacionalidades nacionalidad = new Nacionalidades();

            try
            {
                nacionalidad = contexto.Nacionalidades.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return nacionalidad;
        }


        public static List<Nacionalidades> GetList(Expression<Func<Nacionalidades, bool>> nacionalidad)
        {
            Contexto contexto = new Contexto();
            List<Nacionalidades> listado = new List<Nacionalidades>();

            try
            {
                listado = contexto.Nacionalidades.Where(nacionalidad).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return listado;
        }
    }
}