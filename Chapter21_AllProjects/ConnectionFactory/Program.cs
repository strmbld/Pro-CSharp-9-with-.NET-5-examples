using System;
using System.Data;
using System.Data.Odbc;
using Microsoft.Data.SqlClient;
using ConnectionFactory;

Setup(DataProviderEnum.SqlServer);
Setup(DataProviderEnum.Odbc);
Setup(DataProviderEnum.None);
Console.WriteLine();

void Setup(DataProviderEnum provider)
{
    IDbConnection connection = GetConnection(provider);
    Console.WriteLine($"Connection type: {connection?.GetType().Name ?? "unrecognized"}");
}

IDbConnection GetConnection(DataProviderEnum provider)
    => provider switch
    {
        DataProviderEnum.SqlServer => new SqlConnection(),
        DataProviderEnum.Odbc => new OdbcConnection(),
        _ => null,
    };