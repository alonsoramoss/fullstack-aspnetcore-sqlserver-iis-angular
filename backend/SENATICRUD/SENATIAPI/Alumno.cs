using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SENATIAPI
{
    public class Alumno
    {
        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Dni { get; set; }
        public int Edad { get; set; }
        public bool Enabled { get; set; }
    }

    public class AlumnoGradoInstruccion
    {
        public int AlumnoId { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Dni { get; set; }
        public int Edad { get; set; }
        public bool AlumnoEnabled { get; set; }


        public int GradoInstruccionId { get; set; }
        public string? GradoInstruccionDescripcion { get; set; }
        public bool GradoInstruccionEnabled { get; set; }
    }

    public class AlumnoRequest
    {
        public int Id { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Dni { get; set; }
        public int Edad { get; set; }
        public bool Enabled { get; set; }
    }
}






