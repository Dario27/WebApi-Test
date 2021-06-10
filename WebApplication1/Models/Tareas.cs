using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Tareas
    {
        public int IdTarea { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Descripcion { get; set; }
        public string EstTarea { get; set; }
        public DateTime FechaVence { get; set; }
        public string AutorTarea { get; set; }
        
    }
}