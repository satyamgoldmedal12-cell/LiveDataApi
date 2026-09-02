using System.Data;
using Dapper;
using ERP.Domain.Models;

namespace ERP.Application;

public interface IDivisionService
{
    Task<List<Division>> GetAllDivisionsAsync();
}

public class DivisionService : IDivisionService
{
    private readonly IDbConnection _dbConnection;

    public DivisionService(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<List<Division>> GetAllDivisionsAsync()
    {
        var commandDefinition = new CommandDefinition(
            "BindGroupDivision",
            commandType: CommandType.StoredProcedure,
            commandTimeout: 120  // 5 minutes timeout (default is 30 seconds)
        );

        var divisions = await _dbConnection.QueryAsync<Division>(commandDefinition);

        return   divisions.ToList();
    }


}
