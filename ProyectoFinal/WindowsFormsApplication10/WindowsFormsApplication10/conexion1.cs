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
		private string CadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=bdtexturas; Integrated Security=True";
		private SqlConnection Conexion;

		public SqlConnection EstablecerConexion()
		{
			this.Conexion = new SqlConnection(this.CadenaConexion);
			return this.Conexion;
		}

		public int EjecutarSentenciaRetornaEnteros(SqlCommand sqlComando)
        {
			
			try
			{
				DataSet DS = new DataSet();
				SqlDataAdapter Adaptador = new SqlDataAdapter();
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
				return int.MaxValue;
            }
        }
		public List<String> EjecutarSentenciaRetornaCadenas(SqlCommand sqlComando)
		{
			List<String> empList = null;
			try
			{
				DataSet DS = new DataSet();
				SqlDataAdapter Adaptador = new SqlDataAdapter();
				SqlCommand Comando = new SqlCommand();
				Comando = sqlComando;
				Comando.Connection = this.EstablecerConexion();
				Adaptador.SelectCommand = Comando;
				Conexion.Open();
				Adaptador.Fill(DS);
				Conexion.Close();
				empList = DS.Tables[0].AsEnumerable().Select(dataRow => dataRow.Field<String>("value")).ToList();
				return empList;
			}
			catch
			{
				return empList;
			}
		}

		public DataSet EjecutarSentenciaRetornaDataset(SqlCommand sqlComando)
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
				return DS;
			}
			catch
			{
				return DS;
			}
		}

		public bool EjecutarSentencia(SqlCommand sqlComando)
		{
			try
			{
				SqlCommand Comando = new SqlCommand();
				Comando = sqlComando;
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

	}
}
