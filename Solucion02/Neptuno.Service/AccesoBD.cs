using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Neptuno.Service
{
    public class AccesoBD
    {
        private SqlConnection Cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString);

        public DataTable runConsulta(string comando)
        {
            SqlDataAdapter Dap = new SqlDataAdapter(comando, Cnx);
            DataTable tb = new DataTable();
            Dap.Fill(tb);
            return tb;
        }

        public DataTable runConsultaStore(string comando)
        {
            SqlDataAdapter Dap = new SqlDataAdapter(comando, Cnx);
            Dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable tb = new DataTable();
            Dap.Fill(tb);
            return tb;
        }

        public DataTable runConsulta(string comando, List<SqlParameter> parametros)
        {
            SqlDataAdapter Dap = new SqlDataAdapter(comando, Cnx);
            foreach (SqlParameter item in parametros)
            {
                Dap.SelectCommand.Parameters.Add(item);
            }
            DataTable tb = new DataTable();
            Dap.Fill(tb);
            return tb;
        }

        public DataTable runConsultaStore(string comando, List<SqlParameter> parametros)
        {
            SqlDataAdapter Dap = new SqlDataAdapter(comando, Cnx);
            Dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter item in parametros)
            {
                Dap.SelectCommand.Parameters.Add(item);
            }
            DataTable tb = new DataTable();
            Dap.Fill(tb);
            return tb;
        }

        public SqlDataReader runCursor(string comando)
        {
            SqlCommand cmd = new SqlCommand(comando, Cnx);
            try
            {
                Cnx.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public SqlDataReader runCursor(string comando, List<SqlParameter> parametros)
        {
            SqlCommand cmd = new SqlCommand(comando, Cnx);
            foreach (SqlParameter item in parametros)
            {
                cmd.Parameters.Add(item);
            }
            try
            {
                Cnx.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public int runTransaccionStore(string comando, List<SqlParameter> parametros)
        {

            SqlCommand cmd = new SqlCommand(comando, Cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter item in parametros)
            {
                cmd.Parameters.Add(item);
            }
            try
            {
                Cnx.Open();
                int xresult = cmd.ExecuteNonQuery() >= 1 ? 1 : 0;
                Cnx.Close();
                return xresult;
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public bool runValidaConsulta(string comando, List<SqlParameter> parametros)
        {
            SqlDataAdapter Dap = new SqlDataAdapter(comando, Cnx);
            foreach (SqlParameter item in parametros)
            {
                Dap.SelectCommand.Parameters.Add(item);
            }
            DataTable tb = new DataTable();
            Dap.Fill(tb);
            if (tb.Rows.Count > 0)
                return true;
            else
                return false;
        }

    }
}
