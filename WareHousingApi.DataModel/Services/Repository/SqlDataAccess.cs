using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using WareHousingApi.DataModel.Services.Interface;

namespace WareHousingApi.DataModel.Services.Repository
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration configuration)
        {
            _config = configuration;
        }


        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "WareHousingApiConnectionString")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

        }

        //public async Task<IEnumerable<T>> LoadData<T>(string storedProcedure, string connectionId = "SqlErp")
        //{
        //    using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        //    return await connection.QueryAsync<T>(storedProcedure, null,commandType: CommandType.StoredProcedure);
        //}

        public async Task SaveData<T>(string storedProcedure, T parameter, string connectionId = "WareHousingApiConnectionString")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

            await connection.ExecuteAsync(storedProcedure, parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
