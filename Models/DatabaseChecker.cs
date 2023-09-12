using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient; // Importe o namespace apropriado para o seu provedor de banco de dados.

namespace safemoney.API.Models
{
    public class DatabaseChecker
    {
        private readonly DbConnectionFactory _dbConnectionFactory;

        public DatabaseChecker(DbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public bool IsDatabaseConnected()
        {
            try
            {
                using (var connection = _dbConnectionFactory.CreateConnection())
                {
                    // Tente abrir a conexão e verifique se ela está aberta.
                    connection.Open();
                    return connection.State == ConnectionState.Open;
                }
            }
            catch (SqlException sqlException)
            {
                // Se ocorrer uma exceção específica do SQL Server, você pode tratá-la aqui.
                Console.WriteLine("Erro de conexão com o banco de dados: " + sqlException.Message);
                return false;
            }
            catch (Exception ex)
            {
                // Trate outras exceções genéricas aqui.
                Console.WriteLine("Erro não esperado: " + ex.Message);
                return false;
            }
        }
    }
}
