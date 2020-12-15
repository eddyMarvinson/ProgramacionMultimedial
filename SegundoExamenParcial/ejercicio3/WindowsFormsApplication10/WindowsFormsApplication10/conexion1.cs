using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication10
{
    class conexion1
    {
		private string CadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=dbcolors; Integrated Security=True";
		private SqlConnection Conexion;

		public SqlConnection EstablecerConexion()
		{
			this.Conexion = new SqlConnection(this.CadenaConexion);
			return this.Conexion;
		}
		public bool PruebaConectar()
		{
			try
			{
				SqlCommand Comando = new SqlCommand();
				Comando.CommandText = "SELECT * FROM colorRGB";
				Comando.Connection = this.EstablecerConexion();
				Conexion.Open();
				Comando.ExecuteNonQuery();
				Conexion.Close();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public int EjecutarSentenciaEntero(SqlCommand sqlComando)
        {
			DataSet DS = new DataSet();
			SqlDataAdapter Adaptador = new SqlDataAdapter();
            try
			{
				SqlCommand Comando = new SqlCommand();
				Comando = sqlComando;
				Comando.Connection = this.EstablecerConexion();
				Adaptador.SelectCommand = Comando;
				Conexion.Open();
				Adaptador.Fill(DS);
				Conexion.Close();
				var empList = DS.Tables[0].AsEnumerable().Select(dataRow => dataRow.Field<int>("value")).ToList();
				return empList.ElementAt(0);
			}
            catch
            {
				return -1;
            }
        }

	}
}
