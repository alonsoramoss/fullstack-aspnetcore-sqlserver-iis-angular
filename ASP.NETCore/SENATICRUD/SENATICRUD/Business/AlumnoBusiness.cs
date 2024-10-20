
using SENATIAPI;
using SENATICRUD.Data;

namespace SENATICRUD.Business
{
    public class AlumnoBusiness
    {
        private readonly IConfiguration _configuration;
        public AlumnoBusiness(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Alumno> BListarAlumnos()
        {
            List<Alumno> oRetorno = new List<Alumno>();
            oRetorno = new AlumnoData(_configuration).ListarAlumnos();
            return oRetorno;
        }
 
        public bool BInsertarAlumnos(AlumnoRequest Alumno)
        {
            bool oRetorno;
            oRetorno = new AlumnoData(_configuration).InsertarAlumnos(Alumno);
            return oRetorno;
        }

        public bool BUpdateAlumnos(AlumnoRequest Alumno)
        {
            bool oRetorno;
            oRetorno = new AlumnoData(_configuration).UpdateAlumnos(Alumno);
            return oRetorno;
        }

        public bool BDeleteAlumnos(int AlumnoId)
        {
            bool oRetorno;
            oRetorno = new AlumnoData(_configuration).DeleteAlumnos(AlumnoId);
            return oRetorno;
        }

        public List<AlumnoGradoInstruccion> BListarAlumnosGradoInstruccion()
        {
            List<AlumnoGradoInstruccion> oRetorno = new List<AlumnoGradoInstruccion>();
            oRetorno = new AlumnoData(_configuration).ListarAlumnosGradoInstruccion();
            return oRetorno;
        }
    }
}








