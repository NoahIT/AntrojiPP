using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS
{
    internal class ADMIN_AlterStudents : Database
    {
        public string id {  get; set; }
        public string firstname {  get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string passwordSD { get; set; }
        public string groupSD {  get; set; }

        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        //CREATE
        public void AddStudent() 
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO students (firstname,lastname,username,passwordSD,groupSD)" +
                                  "VALUES (@firstname,@lastname,@username,@passwordSD,@groupSD)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connection;

                cmd.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = firstname;
                cmd.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = lastname;
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = firstname; // taisykle is uzduoties
                cmd.Parameters.Add("@passwordSD", MySqlDbType.VarChar).Value = lastname; // taisykle is uzduoties
                cmd.Parameters.Add("@groupSD", MySqlDbType.VarChar).Value = groupSD;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //UPDATE
        public void UpdateStudent()
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE students SET firstname=@firstname, lastname=@lastname, username=@username," +
                                  "passwordSD=@passwordSD, groupSD=@groupSD WHERE id=@id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connection;

                cmd.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = firstname;
                cmd.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = lastname;
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@passwordSD", MySqlDbType.VarChar).Value = passwordSD;
                cmd.Parameters.Add("@groupSD", MySqlDbType.VarChar).Value = groupSD;

                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //DELETE
        public void DeleteStudent()
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM students WHERE id=@id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connection;


                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //READ
        public void ReadStudents()
        {
            dt.Clear();
            string query = "SELECT * FROM students";
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query,connection);
            mySqlDataAdapter.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
