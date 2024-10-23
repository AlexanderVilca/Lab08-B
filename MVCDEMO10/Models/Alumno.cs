using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDEMO10.Models
{
    public class Alumno
    {
        public int AlumnoID { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public int Grado { get; set; }
    }
}