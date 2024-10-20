using SENATIAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SENATICRUD.Business;

namespace SENATICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly ILogger<AlumnoController> _logger;
        private readonly IConfiguration _configuration;
        public AlumnoController(ILogger<AlumnoController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet]
        [Route("ListarAlumnos")]
        public List<Alumno> ListarAlumnos()
        {
            List<Alumno> oRetorno = new List<Alumno>();
            try
            {
                AlumnoBusiness oAlumnoBussines = new AlumnoBusiness(_configuration);
                oRetorno = oAlumnoBussines.BListarAlumnos();
            }
            catch (Exception)
            {
                oRetorno = new List<Alumno>();
            }
            return oRetorno;
        }

        [HttpPost]
        [Route("InsertarAlumnos")]
        public bool InsertarAlumno(AlumnoRequest Alumno)
        {
            bool oRetorno = true;
            try
            {
                AlumnoBusiness oAlumnoBussines = new AlumnoBusiness(_configuration);
                oRetorno = oAlumnoBussines.BInsertarAlumnos(Alumno);
            }
            catch (Exception)
            {
                throw;
            }
            return oRetorno;
        }

        [HttpPut]
        [Route("ActualizarAlumnos")]
        public bool UpdateAlumno(AlumnoRequest Alumno)
        {
            bool oRetorno = true;
            try
            {
                AlumnoBusiness oAlumnoBussines = new AlumnoBusiness(_configuration);
                oRetorno = oAlumnoBussines.BUpdateAlumnos(Alumno);
            }
            catch (Exception)
            {
                throw;
            }
            return oRetorno;
        }

        [HttpDelete]
        [Route("EliminarAlumnos/{AlumnoId}")]
        public bool DeleteAlumno(int AlumnoId)
        {
            bool oRetorno = true;
            try
            {
                AlumnoBusiness oAlumnoBussines = new AlumnoBusiness(_configuration);
                oRetorno = oAlumnoBussines.BDeleteAlumnos(AlumnoId);
            }
            catch (Exception)
            {
                throw;
            }
            return oRetorno;
        }

        [HttpGet]
        [Route("ListarAlumnosGradoInstruccion")]
        public List<AlumnoGradoInstruccion> ListarAlumnosGradoInstruccion()
        {
            List<AlumnoGradoInstruccion> oRetorno = new List<AlumnoGradoInstruccion>();
            try
            {
                AlumnoBusiness oAlumnoGradoBusiness = new AlumnoBusiness(_configuration);
                oRetorno = oAlumnoGradoBusiness.BListarAlumnosGradoInstruccion();
            }
            catch (Exception)
            {
                oRetorno = new List<AlumnoGradoInstruccion>();
            }
            return oRetorno;
        }
    }
}




