using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using InNLBurgeren.Views;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Cms;
using static System.IO.File;

namespace InNLBurgeren.DatabaseHandling;

public class MySql
{
    public class LoginData
    {
        public string Server;
        public UInt16 Port;
        public string Username;
        public string Password;
        public string Database;
    }

    public Task<MySqlConnection> GetConn()
    {
        string json = File.ReadAllText("DatabaseLogin.json");
        LoginData? loginData = JsonConvert.DeserializeObject<LoginData>(json);
        var builder = new MySqlConnectionStringBuilder
        {
            Server = loginData.Server,
            Database = loginData.Database,
            UserID = loginData.Username,
            Password = loginData.Password,
            Port = loginData.Port,
            SslMode = MySqlSslMode.Required
        };

        MySqlConnection conn;
        return Task.FromResult(conn = new MySqlConnection(builder.ConnectionString));
    }

    public async Task<bool> CheckLogin(string username, string password)
    {
        await using (var conn = GetConn().Result)
        {
            await conn.OpenAsync();
            await using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT username FROM users " +
                                      "WHERE username ='"+ username + "' AND password ='" + password+"'";
                var sqlResponse = await command.ExecuteScalarAsync();
                return sqlResponse != null;
            }
        }
    }

    public async Task<bool> CheckRegister(string username)
    {
        await using (var conn = GetConn().Result)
        {
            await conn.OpenAsync();
            await using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT username FROM users WHERE username = \"" + username + "\"";
                var sqlResponse = await command.ExecuteScalarAsync();
                return sqlResponse != null;
            }
        }
    }

    public async void RegisterAccount(string username, string password)
    {
        await using (var conn = GetConn().Result)
        {
            await conn.OpenAsync();
            await using (var command = conn.CreateCommand())
            {
                command.CommandText = @"INSERT INTO users (username, password) VALUES (@username, @password);";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                await command.ExecuteNonQueryAsync();
            }
        }
    }

    //TODO FIX
    /*
    public async Task<List<Assignments>> GetAssignments()
    {
        await using (var conn = GetConn().Result)
        {
            await conn.OpenAsync();
            await using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM questions";
                
            }
        }
    }
    */
    
    public async void InitializeDatabase()
    {
        await using (var conn = GetConn().Result)
        {
            await conn.OpenAsync();
            await using (var command = conn.CreateCommand())
            {
                command.CommandText = "DROP TABLE IF EXISTS users;";
                await command.ExecuteNonQueryAsync();
                
                command.CommandText = "CREATE TABLE users (id serial PRIMARY KEY, username VARCHAR(150), password VARCHAR(512))";
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Finished creating table");
            }
        }
    }

    public async void Test()
    {
        await using (var conn = GetConn().Result)
        {
            Console.WriteLine("Opening connection");
            await conn.OpenAsync();

            await using (var command = conn.CreateCommand())
            {
                command.CommandText = "DROP TABLE IF EXISTS testmaya;";
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Finished dropping table (if existed)");

                command.CommandText = "CREATE TABLE testmaya (id serial PRIMARY KEY, name VARCHAR(50), quantity INTEGER);";
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Finished creating table");

                command.CommandText = @"INSERT INTO testmaya (name, quantity) VALUES (@name1, @quantity1),
                    (@name2, @quantity2), (@name3, @quantity3);";
                command.Parameters.AddWithValue("@name1", "banana");
                command.Parameters.AddWithValue("@quantity1", 150);
                command.Parameters.AddWithValue("@name2", "orange");
                command.Parameters.AddWithValue("@quantity2", 154);
                command.Parameters.AddWithValue("@name3", "apple");
                command.Parameters.AddWithValue("@quantity3", 100);

                int rowCount = await command.ExecuteNonQueryAsync();
                Console.WriteLine(String.Format("Number of rows inserted={0}", rowCount));
            }

            // connection will be closed by the 'using' block
            Console.WriteLine("Closing connection");
        }

        Console.WriteLine("Press RETURN to exit");
        Console.ReadLine();
        }
    }
