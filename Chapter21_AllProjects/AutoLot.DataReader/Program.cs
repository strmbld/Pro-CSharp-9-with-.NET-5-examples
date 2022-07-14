using System;
using Microsoft.Data.SqlClient;

using (SqlConnection connection = new())
{
    SqlConnectionStringBuilder csb = new()
    {
        DataSource = ".,5433",
        UserID = "sa",
        Password = "P@ssw0rd",
        InitialCatalog = "AutoLot",
        ConnectTimeout = 30,
        Encrypt = false,
    };
    
    connection.ConnectionString = csb.ConnectionString; //@"Data Source=.,5433;User Id=sa;Password=P@ssw0rd;Initial Catalog=Autolot;Encrypt=False";
    connection.Open();

    ShowConnectionStatus(connection);

    string sql =
        @"Select i.id, m.Name as Make, i.Color, i.Petname
          FROM Inventory i
          INNER JOIN Makes m on m.Id = i.MakeId";
    // SqlCommand command = new(sql, connection);
    SqlCommand command = new();
    command.Connection = connection;
    command.CommandText = sql;

    using (SqlDataReader dr = command.ExecuteReader())
    {
        Console.WriteLine("*** Result rows ***");
        while (dr.Read())
        {
            Console.WriteLine($"-> Make: {dr["Make"]}, Name: {dr["PetName"]}, Color: {dr["Color"]}");
        }
    }
}
static void ShowConnectionStatus(SqlConnection connection)
{
    Console.WriteLine("*** Connection Info ***");
    Console.WriteLine($@"DataSource: {connection.DataSource}");
    Console.WriteLine($@"Database: {connection.Database}");
    Console.WriteLine($@"ConnectionTimeout: {connection.ConnectionTimeout}");
    Console.WriteLine($@"State: {connection.State}");
    Console.WriteLine();
}