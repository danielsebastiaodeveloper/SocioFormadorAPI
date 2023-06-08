using Dapper;
using SocioFormador.Domain.Entities;
using SocioFormador.Domain.Interfaces;
using SocioFormador.Domain.Interfaces.Repositories;
using SocioFormador.Persistence.Context;
using System.Data;
using static Dapper.SqlMapper;

namespace SocioFormador.Persistence.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly SocioFormadorDapperDbContext _dbContext;
    private readonly IDateTimeService dateTimeService;

    public ClienteRepository(SocioFormadorDapperDbContext dbContext, IDateTimeService dateTimeService)
    {
        _dbContext = dbContext;
        this.dateTimeService = dateTimeService;
    }

    public async Task<long> CreateAsync(Cliente entity, CancellationToken cancellationToken = default)
    {
        var task = await Task.Run(async () =>
        {
            string sql = "INSERT INTO Clientes (Nombre, Apellido, Email, CiudadId, CreatedBy, CreatedAt) VALUES (@Nombre,  @Apellido, @Email, @CiudadId, @CreatedBy, @CreatedAt);";
            using var con = _dbContext.CreateConnection();

            var result = await con.ExecuteScalarAsync<long>(sql,
        new
        {
            @Nombre = entity.Nombre,
            @Apellido = entity.Apellido,
            @Email = entity.Email,
            @CiudadId = entity.CiudadId,
            @CreatedBy = 1,
            @CreatedAt = dateTimeService.NowUtc
        });
            return result;


        }, cancellationToken);

        return task;
    }

    public Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Cliente>> GetAllAsync(object? param = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<Cliente> GetEntityByIdAsync(long Id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Cliente entity, long Id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
