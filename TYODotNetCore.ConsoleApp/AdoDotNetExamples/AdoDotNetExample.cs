using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYODotNetCore.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Read() {
            Console.WriteLine("Starting The C# Program!!");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "LAPTOP-GF6QM6AD\\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa@123";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tbl_Blog]";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            sqlConnection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
            }
        }

        public void Edit(int id )
        {
            Console.WriteLine("Starting The C# Program!!");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "LAPTOP-GF6QM6AD\\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa@123";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();


            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
  FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            sqlConnection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("Data not found!!");
                return;
            }

            DataRow dr = dt.Rows[0];

            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
        }

        public void Create(string title, string author, string content)
        {
            Console.WriteLine("Starting The C# Program!!");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "LAPTOP-GF6QM6AD\\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa@123";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();


            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent)";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("Create successful...");
            } else
            {
                Console.WriteLine("Create failed...");
            }
        }

        public void Update(int id, string title, string author, string content)
        {
            Console.WriteLine("Starting The C# Program!!");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "LAPTOP-GF6QM6AD\\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa@123";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();


            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("Update successful...");
            }
            else
            {
                Console.WriteLine("Update failed...");
            }
        }

        public void Delete(int id)
        {
            Console.WriteLine("Starting The C# Program!!");

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "LAPTOP-GF6QM6AD\\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "sasa@123";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();


            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("Delete successful...");
            }
            else
            {
                Console.WriteLine("Delete failed...");
            }
        }
    }
}
