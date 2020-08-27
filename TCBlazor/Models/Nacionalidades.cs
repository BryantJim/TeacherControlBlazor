using System;
using System.ComponentModel.DataAnnotations;

namespace TCBlazor.Models
{
    public class Nacionalidades
    {
        [Key]
        public int NacionalidadId { get; set; }
        public string Nacionalidad { get; set; }
    }
}