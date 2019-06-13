using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


//Using ADO.NET
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace AcessoBanco
{
    public class AcessoDados
    {
        // Criar a conexão com o banco de dados
        public SqlConnection CriarConexao()
        {
            //return new SqlConnection(Properties.Settings.Default.Conn);

            var conStr = ConfigurationManager.ConnectionStrings["AcessoBanco"].ConnectionString;

            return new SqlConnection(conStr);
        }

        // Parâmetros que irão para o banco
        SqlParameterCollection SqlParameterCollection = new SqlCommand().Parameters;

        public void LimparParametro()
        {
            SqlParameterCollection.Clear();
        }

        public void AdicionarParametro(string nomeP, string valor)
        {
            //Adicionar parâmetros
            SqlParameterCollection.Add(new SqlParameter(nomeP, valor));
        }

        public object ExecutarPersistência(CommandType cmdoType,
                                        string textoSql,
                                        bool read = true)
        {

            try
            {
                // Criar a conexão com a base de dados
                SqlConnection sqlConnection = CriarConexao();
                // Abrir a conexão
                sqlConnection.Open();
                // Criar o comando que vai até o bd
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                //Adicionar os dados dentro do comando
                sqlCommand.CommandType = cmdoType;
                sqlCommand.CommandText = textoSql;
                sqlCommand.CommandTimeout = 3600;

                // Varre os parâmetros e coloca o nome e o valor do pârametro
                foreach (SqlParameter sqlParameter in SqlParameterCollection)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(sqlParameter.ParameterName,
                                                                sqlParameter.Value));
                }
                if (read) return sqlCommand.ExecuteReader();
                else return sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public class Class1
        {
        }
    }
}
