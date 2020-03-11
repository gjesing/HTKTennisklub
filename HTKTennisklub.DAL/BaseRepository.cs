using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTKTennisklub.DAL
{
    public abstract class BaseRepository
    {
        private string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=HTKTennisklub;Integrated Security=True";

        /// <summary>
        /// Initializes a new instance of the BaseRepository class
        /// </summary>
        public BaseRepository()
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("You must set the connectionString field manually!");
            }
        }

        /// <summary>
        /// Method used to make a query to the database with an SQL statement
        /// that maintains data in the database. The SQL statement should be INSERT, DELETE or UPDATE.
        /// </summary>
        /// <param name="sql">The SQL statement to be sent to the database</param>
        /// <exception cref="SqlException">Thrown when the server returns a warning or error.</exception>
        protected int ExecuteNonQuery(string sql)
        {
            int affectedRows = 0; //Used to store the affected rows

            //Uses the connection and command
            //The using makes sure to close and dispose the objects in the end
            using (var con = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, con))
            {
                con.Open();
                affectedRows = command.ExecuteNonQuery();
            }

            return affectedRows;
        }

        /// <summary>
        /// Method used to make a query for data in the database.
        /// This is used with an SQL statement using SELECT.
        /// </summary>
        /// <param name="sql">The SQL statement to be sent to the database</param>
        /// <exception cref="SqlException">Thrown when the server returns a warning or error.</exception>
        /// <returns>A DataSet object containing the result</returns>
        protected DataTable ExecuteQuery(string sql)
        {
            DataTable dataTable = new DataTable(); //The dataset to be returned

            //Uses the connection and command
            //The using makes sure to close and dispose the objects in the end
            using (var con = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, con))
            {
                //Open the connection
                con.Open();
                //Get the data from the database
                SqlDataAdapter da = new SqlDataAdapter(command);

                da.Fill(dataTable);
            }
            return dataTable;
        }
    }
}
