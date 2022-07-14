using System;
using System.Data.Common;
using System.Data.Odbc;
using System.IO;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using DataProviderFactory;

var (provider, connectionString) = GetProviderFromConfig();
DbProviderFactory factory = GetDbProviderFactory(provider);
using(DbConnection connection = factory.CreateConnection())
{
    if (connection == null)
    {
        Console.WriteLine("Unable to create connection object");
        return;
    }
    Console.WriteLine($"Connection object: {connection.GetType().Name}");
    connection.ConnectionString = connectionString;
    connection.Open();

    DbCommand command = factory.CreateCommand();
    if (command == null)
    {
        Console.WriteLine("Unable to create command obj");
        return;
    }
    Console.WriteLine($"Command obj: {command.GetType().Name}");
    command.Connection = connection;
    command.CommandText =
        "Select i.Id, m.Name From Inventory i inner join Makes m on m.Id = i.MakeId";

    using (DbDataReader dataReader = command.ExecuteReader())
    {
        Console.WriteLine($"Data reader obj: {dataReader.GetType().Name}");
        Console.WriteLine("*** Current Inventory ***");
        while (dataReader.Read())
        {
            Console.WriteLine($"-> Car #{dataReader["Id"]} is a {dataReader["Name"]}");
        }
    }
}
static DbProviderFactory GetDbProviderFactory(DataProviderEnum provider)
    => provider switch
    {
        DataProviderEnum.SqlServer => SqlClientFactory.Instance,
        DataProviderEnum.Odbc => OdbcFactory.Instance,
        _ => null,
    };
static (DataProviderEnum provider, string connectionString) GetProviderFromConfig()
{
    IConfiguration config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .Build()
        ;
    var providerName = config["ProviderName"];
    if (Enum.TryParse<DataProviderEnum>(providerName, out DataProviderEnum provider))
    {
        return (provider, config[$"{providerName}:ConnectionString"]);
    }
    throw new Exception("Invalid data provider value supplied");
}