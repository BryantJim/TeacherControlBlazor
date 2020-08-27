using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TCBlazor.Models
{
    public class Tareas
    {
        [Key]
        public int TareaId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        public float Puntos { get; set; }

        [ForeignKey("TareaId")]
        public List<TareasDetalle> Detalle { get; set; } = new List<TareasDetalle>();
    }
}