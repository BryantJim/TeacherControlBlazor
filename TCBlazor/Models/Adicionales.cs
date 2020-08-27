using System;
using System.ComponentModel.DataAnnotations;

namespace TCBlazor.Models
{
    public class Adicionales
    {
        [Key]
        public int AdicionalId { get; set; }
        public DateTime Fecha { get; set; }
        public int EstudianteId { get; set; }
        public float Puntos { get; set; }
    }
}