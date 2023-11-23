using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AMS.MVVM.Model
{
    internal class LogInLogic : Database
    {
        public string usernameLOG { get; set; }
        public string passwordLOG { get; set; }
        public UserProperties LogValidation(string Username, string Password)
        {
            usernameLOG = Username;
            passwordLOG = Password;
            
            try
            {
                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "SELECT username, passwordSD FROM students " +
                                      "WHERE usernameLOG=@username AND passwordLOG=@passwordSD";
                    cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = usernameLOG;
                    cmd.Parameters.Add("@passwordSD", MySqlDbType.VarChar).Value = passwordLOG;
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        usernameLOG = (string)reader["username"];
                        passwordLOG = (string)reader["password"];
                        return new UserProperties(usernameLOG, passwordLOG, "student");
                    }
                    reader.Close();
                }

                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "SELECT username, passwordLD FROM lecturers " +
                                      "WHERE usernameLOG=@username AND passwordLOG=@passwordLD";
                    cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = usernameLOG;
                    cmd.Parameters.Add("@passwordLD", MySqlDbType.VarChar).Value = passwordLOG;
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        usernameLOG = (string)reader["username"];
                        passwordLOG = (string)reader["password"];
                        return new UserProperties(usernameLOG, passwordLOG, "lecturer");
                    }
                    reader.Close();
                }

                connection.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "SELECT username, passwordAD FROM adminAD " +
                                      "WHERE usernameLOG=@username AND passwordLOG=@passwordAD";
                    cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = usernameLOG;
                    cmd.Parameters.Add("@passwordAD", MySqlDbType.VarChar).Value = passwordLOG;
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        usernameLOG = (string)reader["username"];
                        passwordLOG = (string)reader["password"];
                        return new UserProperties(usernameLOG, passwordLOG, "admin");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return new UserProperties();
        }
    }
}
