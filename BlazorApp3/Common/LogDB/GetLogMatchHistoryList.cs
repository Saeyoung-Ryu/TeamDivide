using System.Data;
using BlazorApp3.Common;
using BlazorApp3.Common.Type;
using Dapper;
using MySqlConnector;

namespace BlazorApp3.Common
{
    public partial class LogDB
    {
        public static async Task<List<LogMatchHistory>> GetLogMatchHistoryAsync()
        {
            await using (var conn = new MySqlConnection(Config.ConnectionString))
            {
                return await SpGetLogMatchHistoryAsync(conn, null);
            }
        }

        private static async Task<List<LogMatchHistory>> SpGetLogMatchHistoryAsync(MySqlConnection conn, MySqlTransaction trxn)
        {
            var parameters = new DynamicParameters();

            return (await conn.QueryAsync<LogMatchHistory>("spGetLogMatchHistoryList", parameters, trxn, commandType: CommandType.StoredProcedure)).ToList();
        }
    }
}




