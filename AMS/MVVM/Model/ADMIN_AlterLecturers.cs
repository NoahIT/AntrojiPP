using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.MVVM.Model
{
    internal class ADMIN_AlterLecturers : Database
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string passwordLD { get; set; }
        public string subjectLD { get; set; }

        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        //CREATE
        public void AddLecturer()
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO lecturers (firstname,lastname,username,passwordLD,subjectLD)" +
                                  "VALUES (@firstname,@lastname,@username,@passwordLD,@subjectLD)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connection;

                cmd.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = firstname;
                cmd.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = lastname;
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = firstname; // taisykle is uzduoties
                cmd.Parameters.Add("@passwordLD", MySqlDbType.VarChar).Value = lastname; // taisykle is uzduoties
                cmd.Parameters.Add("@subjectLD", MySqlDbType.VarChar).Value = subjectLD;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //UPDATE
        public void UpdateLecturer()
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE lecturers SET firstname=@firstname, lastname=@lastname, username=@username," +
                                  "passwordLD=@passwordLD, subjectLD=@subjectLD WHERE id=@id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connection;

                cmd.Parameters.Add("@firstname", MySqlDbType.VarChar).Value = firstname;
                cmd.Parameters.Add("@lastname", MySqlDbType.VarChar).Value = lastname;
                cmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@passwordLD", MySqlDbType.VarChar).Value = passwordLD;
                cmd.Parameters.Add("@subjectLD", MySqlDbType.VarChar).Value = subjectLD;

                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //DELETE
        public void DeleteLecturer()
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM lecturers WHERE id=@id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connection;

                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //READ
        public void ReadLecturers()
        {
            dt.Clear();
            string query = "SELECT * FROM lecturers";
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, connection);
            mySqlDataAdapter.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
