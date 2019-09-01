using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonTest.Application.Queries
{
    public class SuggestionQueries : ISuggestionQueries
    {
        private string _connectionString;

        public SuggestionQueries(string connectionString)
        {
            _connectionString = !string.IsNullOrEmpty(connectionString)? connectionString : throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<IEnumerable<string>> GetSuggestions(string input)
        {
            using(var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var result = await connection.QueryAsync<string>("SELECT words FROM phrases WHERE words ILIKE @input limit 10;",
                    new {input = $"{input}%" });

                return result;
            }            
        }
    }
}
