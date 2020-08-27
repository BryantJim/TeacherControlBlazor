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
   public class AdicionalesBLL
    {
        public static bool Guardar(Adicionales Adicional)
        {
            if (!Existe(Adicional.AdicionalId))
            {
               return Insertar(Adicional);
            }
            else
            {
               return Modificar(Adicional);
            }

          
        }

        private static bool Insertar(Adicionales Adicional)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Adicionales.Add(Adicional);
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

        private static bool Modificar(Adicionales Adicional)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(Adicional).State = EntityState.Modified;
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
                encontrado = contexto.Adicionales.Any(d => d.AdicionalId == id);
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
                var eliminar = contexto.Adicionales.Find(id);
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

        public static Adicionales Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Adicionales Adicional = new Adicionales();

            try
            {
                Adicional = contexto.Adicionales.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Adicional;
        }


        public static List<Adicionales> GetList(Expression<Func<Adicionales, bool>> Adicional)
        {
            Contexto contexto = new Contexto();
            List<Adicionales> listado = new List<Adicionales>();

            try
            {
                listado = contexto.Adicionales.Where(Adicional).ToList();
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