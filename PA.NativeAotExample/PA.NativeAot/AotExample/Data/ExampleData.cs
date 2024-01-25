using System.Data.Common;
using Dapper;

[module: DapperAot]

namespace AotExample.Data;


public class ExampleData
{
    private readonly DbConnection _connection;

    public ExampleData(DbConnection connection)
    {
        _connection = connection;
    }

    public async Task<TableExample[]> GetAll()
        => (await _connection.QueryAsync<TableExample>("select * from table_example")).ToArray();


    public async Task<TableExample> GetById(int id)
        => await _connection.QuerySingleAsync<TableExample>("select * from table_example where column1 = @id",
            new { id });
}