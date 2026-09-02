using System.Data;
using Dapper;
using ERP.Domain.Models;

namespace ERP.Application;

public interface ITaxTypeService
{
    Task<int> AddTaxTypeAsync(TaxType taxType, int crtuId, int logon);
    Task<int> UpdateTaxTypeAsync(TaxType taxType, int crtuId, int logon);
    Task<int> DeleteTaxTypeAsync(int recId, int crtuId, int logon);
}

public class TaxTypeService : ITaxTypeService
{
    private readonly IDbConnection _dbConnection;

    public TaxTypeService(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<int> AddTaxTypeAsync(TaxType taxType, int crtuId, int logon)
    {
        var commandDefinition = new CommandDefinition(
            "taxtypeadd",
            new
            {
                taxtypenm1 = taxType.TaxTypeNm,
                taxtypecode1 = taxType.TaxTypeCode,
                crtuid1 = crtuId,
                logon1 = logon,
                recid = 0,
                StatementType = "INSERT"
            },
            commandType: CommandType.StoredProcedure,
            commandTimeout: 300
        );
        return await _dbConnection.ExecuteAsync(commandDefinition);
    }

    public async Task<int> UpdateTaxTypeAsync(TaxType taxType, int crtuId, int logon)
    {
        var commandDefinition = new CommandDefinition(
            "taxtypeadd",
            new
            {
                taxtypenm1 = taxType.TaxTypeNm,
                taxtypecode1 = taxType.TaxTypeCode,
                crtuid1 = crtuId,
                logon1 = logon,
                recid = taxType.RecId,
                StatementType = "UPDATE"
            },
            commandType: CommandType.StoredProcedure,
            commandTimeout: 300
        );

        return await _dbConnection.ExecuteAsync(commandDefinition);
    }

    public async Task<int> DeleteTaxTypeAsync(int recId, int crtuId, int logon)
    {
        var commandDefinition = new CommandDefinition(
            "taxtypeadd",
            new
            {
                taxtypenm1 = "",
                taxtypecode1 = "",
                crtuid1 = crtuId,
                logon1 = logon,
                recid = recId,
                StatementType = "DELETE"
            },
            commandType: CommandType.StoredProcedure,
            commandTimeout: 300
        );

        return await _dbConnection.ExecuteAsync(commandDefinition);
    }
}
