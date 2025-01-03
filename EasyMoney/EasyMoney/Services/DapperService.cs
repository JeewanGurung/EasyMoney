using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static Dapper.SqlMapper;

namespace EasyMoney.Services
{
    public abstract class DapperService
    {
        private readonly IConfiguration _configuration;
        private string _connectionString;

        protected DapperService(IConfiguration configuration)
        {
          _connectionString = configuration.GetSection("DefaultConnection").Value;
        }

        protected IDbConnection Connection => new SqlConnection(_connectionString);

        protected async Task<List<T>> GetQueryResultAsync<T>(string sQuery, object parameters = null, IDbTransaction transaction = null)
        {

            var command = new CommandDefinition(sQuery, parameters, transaction);

            var result = await Connection.QueryAsync<T>(command);

            return result.ToList();

        }
        protected async Task<T> GetQueryFirstOrDefaultResultAsync<T>(string sQuery, object parameters, IDbTransaction transaction = null)
        {

            var command = new CommandDefinition(sQuery, parameters, transaction);

            var result = await Connection.QueryFirstOrDefaultAsync<T>(command);

            return result;
        }
        protected async Task<int> ExecuteAsync(string sQuery, object parameters, IDbTransaction transaction = null)
        {

            var command = new CommandDefinition(sQuery, parameters, transaction);

            var rowsAffected = await Connection.ExecuteAsync(command);

            return rowsAffected;
        }

        protected async Task<GridReader> GetFromMultipleQuery(string sQuery, object parameters, IDbTransaction transaction = null)
        {

            var command = new CommandDefinition(sQuery, parameters, transaction);

            var result = await Connection.QueryMultipleAsync(command);

            return result;
        }
    }
}
