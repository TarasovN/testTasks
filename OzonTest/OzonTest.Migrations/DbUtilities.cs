using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OzonTest.Migrations
{
    public class DbUtilities
    {
        public static bool DBExists(string connectionStr, string dbname)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionStr))
            {
                string sql = $"SELECT DATNAME FROM pg_catalog.pg_database WHERE DATNAME = '{dbname}'";
                using (NpgsqlCommand command = new NpgsqlCommand
                    (sql, conn))
                {
                    try
                    {
                        conn.Open();
                        var i = command.ExecuteScalar();
                        conn.Close();
                        if (i != null && i.ToString().Equals(dbname)) 
                            return true;
                        else return false;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        return false;
                    }
                }
            }
        }

        public static bool CreateDB(string connectionStr, string dbname)
        {            
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionStr))
            {
                string sql = $"CREATE DATABASE {dbname} WITH OWNER = postgres ENCODING = 'UTF8' CONNECTION LIMIT = -1;";
                using (NpgsqlCommand command = new NpgsqlCommand
                    (sql, conn))
                {
                    try
                    {
                        conn.Open();
                        command.ExecuteScalar();
                        conn.Close();
                       
                        return true;                       
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        return false;
                    }
                }
            }
        }

        public static bool FillTestData(string connectionStr)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(connectionStr))
            {
                try
                {
                    conn.Open();

                    using (var writer = conn.BeginTextImport("COPY phrases (words) FROM STDIN"))
                    {
                        var lines = File.ReadLines("Data.txt");
                        foreach (var line in lines)
                            writer.WriteLine(line);
                    }

                    conn.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    return false; 
                }
                
            }

            
        }
    }
}
