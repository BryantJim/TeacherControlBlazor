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
   public class EstudiantesBLL
    {
        public static bool Guardar(Estudiantes estudiante)
        {
            if (!Existe(estudiante.EstudianteId))
            {
               return Insertar(estudiante);
            }
            else
            {
               return Modificar(estudiante);
            }

          
        }

        private static bool Insertar(Estudiantes estudiante)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Estudiantes.Add(estudiante);
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

        private static bool Modificar(Estudiantes estudiante)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(estudiante).State = EntityState.Modified;
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
                encontrado = contexto.Estudiantes.Any(d => d.EstudianteId == id);
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
                var eliminar = contexto.Estudiantes.Find(id);
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

        public static Estudiantes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Estudiantes estudiante = new Estudiantes();

            try
            {
                estudiante = contexto.Estudiantes.Find(id);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return estudiante;
        }


        public static List<Estudiantes> GetList(Expression<Func<Estudiantes, bool>> estudiante)
        {
            Contexto contexto = new Contexto();
            List<Estudiantes> listado = new List<Estudiantes>();

            try
            {
                listado = contexto.Estudiantes.Where(estudiante).ToList();
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