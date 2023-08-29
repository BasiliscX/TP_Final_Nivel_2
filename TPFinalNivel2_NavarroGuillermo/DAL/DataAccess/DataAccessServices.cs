using System;
using System.Data.SqlClient;

namespace DAL.DataAccess
{
    public class DataAccessServices
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;

        public SqlDataReader Reader { get { return _reader; } }
        public DataAccessServices()
        {
            _connection = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true");
            _command = new SqlCommand();
        }
        public void SetConsulta(string consulta)
        {
            _command.CommandType=System.Data.CommandType.Text;
            _command.CommandText=consulta;
        }
        public void EjecutarLectura()
        {
            _command.Connection = _connection;
            try
            {
                _connection.Open();
                _reader = _command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EjecutarAccion()
        {
            _command.Connection = _connection;
            try
            {
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CerrarConexion() { if (_reader != null) { _reader.Close(); } _connection.Close(); }
        public void SetParametros(string nombre, object valor) { _command.Parameters.AddWithValue(nombre, valor); }
    }
}
