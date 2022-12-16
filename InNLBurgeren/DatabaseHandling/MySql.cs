using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public async void Connect()
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
                SslMode = MySqlSslMode.Required,
            };
            
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("Opening connection");
                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
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
