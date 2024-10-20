using SENATIAPI;
using Microsoft.Data.SqlClient;
using System.Data;

namespace SENATICRUD.Data
{
    public class AlumnoData
    {
        private readonly IConfiguration _configuration;
        public AlumnoData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Alumno> ListarAlumnos()
        {
            List<Alumno> objRetorno = new List<Alumno>();

            using (SqlConnection cn = new SqlConnection(_configuration["ConnectionStrings:myconn"]))
            {
                SqlCommand cmd = new SqlCommand();
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = @"ListarAlumnos";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Alumno obj = new Alumno();
                        obj.Id = (reader["Id"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Id"]);
                        obj.Nombres = (reader["Nombres"] == DBNull.Value) ? String.Empty : Convert.ToString(reader["Nombres"]);
                        obj.Apellidos = (reader["Apellidos"] == DBNull.Value) ? String.Empty : Convert.ToString(reader["Apellidos"]);
                        obj.Dni = (reader["Dni"] == DBNull.Value) ? String.Empty : Convert.ToString(reader["Dni"]);
                        obj.Edad = (reader["Edad"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Edad"]);
                        obj.Enabled = (reader["Enabled"] != DBNull.Value) ? Convert.ToBoolean(reader["Enabled"]) : false;
                        objRetorno.Add(obj);
                    }
                    cn.Close();
                }
                return objRetorno;
            }
        }

        public bool InsertarAlumnos(AlumnoRequest Alumno)
        {
            bool oRetorno = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration["ConnectionStrings:myconn"]))
                {
                    SqlCommand cmd = new SqlCommand();
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = @"InsertarAlumnos";

                    cmd.Parameters.Add($"@{nameof(Alumno.Nombres)}", SqlDbType.VarChar).Value = Alumno.Nombres;
                    cmd.Parameters.Add($"@{nameof(Alumno.Apellidos)}", SqlDbType.VarChar).Value = Alumno.Apellidos;
                    cmd.Parameters.Add($"@{nameof(Alumno.Dni)}", SqlDbType.VarChar).Value = Alumno.Dni;
                    cmd.Parameters.Add($"@{nameof(Alumno.Edad)}", SqlDbType.Int).Value = Alumno.Edad;
                    cmd.Parameters.Add($"@{nameof(Alumno.Enabled)}", SqlDbType.Bit).Value = Alumno.Enabled;
                    cmd.ExecuteNonQuery();
                    oRetorno = true;
                    cn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oRetorno;
        }

        public bool UpdateAlumnos(AlumnoRequest Alumno)
        {
            bool oRetorno = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration["ConnectionStrings:myconn"]))
                {
                    SqlCommand cmd = new SqlCommand();
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = @"UpdateAlumnos";

                    cmd.Parameters.Add($"@{nameof(Alumno.Id)}", SqlDbType.Int).Value = Alumno.Id;
                    cmd.Parameters.Add($"@{nameof(Alumno.Nombres)}", SqlDbType.VarChar).Value = Alumno.Nombres;
                    cmd.Parameters.Add($"@{nameof(Alumno.Apellidos)}", SqlDbType.VarChar).Value = Alumno.Apellidos;
                    cmd.Parameters.Add($"@{nameof(Alumno.Dni)}", SqlDbType.VarChar).Value = Alumno.Dni;
                    cmd.Parameters.Add($"@{nameof(Alumno.Edad)}", SqlDbType.Int).Value = Alumno.Edad;
                    cmd.Parameters.Add($"@{nameof(Alumno.Enabled)}", SqlDbType.Bit).Value = Alumno.Enabled;
                    cmd.ExecuteNonQuery();
                    oRetorno = true;
                    cn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oRetorno;
        }

        public bool DeleteAlumnos(int AlumnoId)
        {
            bool oRetorno = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(_configuration["ConnectionStrings:myconn"]))
                {
                    SqlCommand cmd = new SqlCommand();
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = @"sp_DeleteAlumnos";

                    cmd.Parameters.Add($"@{nameof(Alumno.Id)}", SqlDbType.Int).Value = AlumnoId;
                    cmd.ExecuteNonQuery ();
                    oRetorno = true;
                    cn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oRetorno;
        }

        public List<AlumnoGradoInstruccion> ListarAlumnosGradoInstruccion()
        {
            List<AlumnoGradoInstruccion> oRetorno = new List<AlumnoGradoInstruccion>();

            using (SqlConnection cn = new SqlConnection(_configuration["ConnectionStrings:myconn"]))
            {
                SqlCommand cmd = new SqlCommand();
                cn.Open();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = @"ListarAlumnosGradoInstruccion";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AlumnoGradoInstruccion obj = new AlumnoGradoInstruccion();
                        obj.AlumnoId = (reader["AlumnoId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["AlumnoId"]);
                        obj.Nombres = (reader["Nombres"] == DBNull.Value) ? String.Empty : Convert.ToString(reader["Nombres"]);
                        obj.Apellidos = (reader["Apellidos"] == DBNull.Value) ? String.Empty : Convert.ToString(reader["Apellidos"]);
                        obj.Dni = (reader["Dni"] == DBNull.Value) ? String.Empty : Convert.ToString(reader["Dni"]);
                        obj.Edad = (reader["Edad"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Edad"]);
                        obj.AlumnoEnabled = (reader["AlumnoEnabled"] != DBNull.Value) ? Convert.ToBoolean(reader["AlumnoEnabled"]) : false;

                        obj.GradoInstruccionId = (reader["GradoInstruccionId"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["GradoInstruccionId"]);
                        obj.GradoInstruccionDescripcion = (reader["GradoInstruccionDescripcion"] == DBNull.Value) ? String.Empty : Convert.ToString(reader["GradoInstruccionDescripcion"]);
                        obj.GradoInstruccionEnabled = (reader["GradoInstruccionEnabled"] != DBNull.Value) ? Convert.ToBoolean(reader["GradoInstruccionEnabled"]) : false;

                        oRetorno.Add(obj);
                    }
                }
                cn.Close();
            }
            return oRetorno;
        }
    }
}




