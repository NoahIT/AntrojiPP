using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AMS.MVVM.Model
{
    internal class LECTUR_AlterStudentGrades : Database
    {
        public string id { get; set; }
        public string student_id { get; set; }
        public string grade_id { get; set; }
        public string additional_info { get; set; }

        public DataTable dt = new DataTable();
        private DataSet ds = new DataSet();

        //CREATE
        public void AddGrade()
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "INSERT INTO student_grades (student_id, grade_id, additional_info)" +
                                  "VALUES (@student_id,@grade_id,@additional_info)";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connection;

                cmd.Parameters.Add("@student_id", MySqlDbType.VarChar).Value = student_id;
                cmd.Parameters.Add("@grade_id", MySqlDbType.VarChar).Value = grade_id;
                cmd.Parameters.Add("@additional_info", MySqlDbType.VarChar).Value = additional_info;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //UPDATE
        public void UpdateGrade()
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE student_grades SET additional_info=@additional_info WHERE id=@id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connection;

                cmd.Parameters.Add("@additional_info", MySqlDbType.VarChar).Value = additional_info;

                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //DELETE
        public void DeleteGrade()
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "DELETE FROM students_grades WHERE id=@id";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = connection;

                cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        //READ
        public void ReadGrade()
        {
            dt.Clear();
            string query = "SELECT * FROM students_grades";
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(query, connection);
            mySqlDataAdapter.Fill(ds);
            dt = ds.Tables[0];
        }
    }
}
