// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using TYODotNetCore.ConsoleApp.AdoDotNetExamples;
using TYODotNetCore.ConsoleApp.DapperExamples;
using TYODotNetCore.ConsoleApp.EFCoreExamples;

//Console.WriteLine("Starting The C# Program!!");

//SqlConnectionStringBuilder  sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
//sqlConnectionStringBuilder.DataSource = "LAPTOP-GF6QM6AD\\SQLEXPRESS"; 
//sqlConnectionStringBuilder.InitialCatalog = "TestDb";
//sqlConnectionStringBuilder.UserID = "sa";
//sqlConnectionStringBuilder.Password = "sasa@123";

//SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
//sqlConnection.Open();

//string query = "select * from tbl_blog";

//SqlCommand cmd = new SqlCommand(query, sqlConnection);
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();

//adapter.Fill(dt);

//sqlConnection.Close();

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr["BlogId"]);
//    Console.WriteLine(dr["BlogTitle"]);
//    Console.WriteLine(dr["BlogAuthor"]);
//    Console.WriteLine(dr["BlogContent"]);
//}

//Console.ReadKey();


//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit(1);
//adoDotNetExample.Create("Thu Yein", "Min Thar", "Saw Kyi Bl");
//adoDotNetExample.Update(9, "Thu Yein Oo", "Developer", "Saw Ma Shi Pr");
//adoDotNetExample.Delete(9);

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit(1);
//dapperExample.Create("Thu Yein Nay Min", "Min Thar Gyi", "Saw Kyi Bl");
//dapperExample.Update(14, "Thu Yein Nay Min", "Min Thar Gyi", "Single");
//dapperExample.Delete(14);

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Read();
eFCoreExample.Edit(1);
eFCoreExample.Create("Thu Yein Nay Min", "Min Thar Gyi", "Saw Kyi Bl Single");
eFCoreExample.Update(15, "Thu Yein Nay Min", "Min Thar Gyi", "Single");
eFCoreExample.Delete(15);
