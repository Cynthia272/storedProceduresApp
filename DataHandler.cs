using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace storedProceduresApp
{
    class DataHandler
    {
        string connectionString = @"Data Source=SINETHETER72\SQLEXPRESS;Initial Catalog=testDb;Integrated Security=True";

        public DataTable students = new DataTable();
        SqlConnection conn;

        public void displayStudents()
        {
            using (conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("spGetStudents", conn); //inititialising data adapter with values below
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;//specify type of command to use. specify whether its normal text or sql used
                adapter.Fill(students);


            }
        }
        public void insertData(int id, string name, string surname, string course)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("spAddStudent", conn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Surname", surname);
            cmd.Parameters.AddWithValue("@Course", course);

           
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
