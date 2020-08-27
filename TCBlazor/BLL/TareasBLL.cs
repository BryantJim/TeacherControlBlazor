using System;
using System.Collections.Generic;
using System.Text;
using TCBlazor.Models;
using TCBlazor.DAL;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TCBlazor.BLL
{
    public class TareasBLL
    {
        public static bool Guardar(Tareas tarea)
        {
            if (!Existe(tarea.TareaId))
            {
                return Insertar(tarea);
            }
            else
            {
                return Modificar(tarea);
            }

        }

        public static bool Insertar(Tareas tarea)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Tareas.Add(tarea) != null)
                    paso = (contexto.SaveChanges() > 0);
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

        public static bool Modificar(Tareas tarea)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM TareasDetalle Where TareasId={tarea.TareaId}");
                foreach(var item in tarea.Detalle)
                {
                   contexto.Entry(item).State = EntityState.Added;
                }
                contexto.Entry(tarea).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
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

        public static Tareas Buscar(int id)
        {
            Tareas tarea = new Tareas();
            Contexto contexto = new Contexto();

            try
            {
                tarea = contexto.Tareas.Include(x => x.Detalle).Where(x => x.TareaId == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return tarea;
        }

        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Tareas.Any(d => d.TareaId == id);
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
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = TareasBLL.Buscar(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;
                paso = (contexto.SaveChanges() > 0);
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

        public static List<Tareas> GetList(Expression<Func<Tareas, bool>> tarea)
        {
            List<Tareas> Lista = new List<Tareas>();
            Contexto contexto = new Contexto();

            try
            {
                Lista = contexto.Tareas.Where(tarea).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Lista;
        }

    }
}