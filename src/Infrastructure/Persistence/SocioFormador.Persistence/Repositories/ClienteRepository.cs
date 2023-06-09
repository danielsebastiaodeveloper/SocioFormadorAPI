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
            string sql = "INSERT INTO Clientes (Nombre, Apellido, Email, CiudadId, CreatedBy, CreatedAt) " +
            "VALUES (@Nombre, @Apellido, @Email, @CiudadId, @CreatedBy, @CreatedAt); " +
            "SELECT LAST_INSERT_ID();";
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

    public async Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default)
    {
        var check = await GetEntityByIdAsync(Id);
        if (check is not null)
        {
            var task = await Task.Run(async () =>
            {
                string sql = "DELETE FROM Clientes WHERE Id = @Id";
                using var con = _dbContext.CreateConnection();
                var result = await con.ExecuteAsync(sql, new { @Id = Id });
                return result > 0;
            }, cancellationToken);
            return task;
        }
        return false;
    }

    public Task<IEnumerable<Cliente>> GetAllAsync(object? param = null, CancellationToken cancellationToken = default)
    {
        var task = Task.Run(async () =>
        {
            string query = "SELECT Id, Nombre, Apellido, Email, CiudadId FROM Clientes;";
            using var con = _dbContext.CreateConnection();
            var result = await con.QueryAsync<Cliente>(query);
            return result;
        }, cancellationToken);

        return task;
    }

    public async Task<Cliente> GetEntityByIdAsync(long Id, CancellationToken cancellationToken = default)
    {
        var task = await Task.Run(async () =>
        {
            string query = "SELECT Id, Nombre, Apellido, Email, CiudadId FROM Clientes WHERE Id = @Id;";
            using var con = _dbContext.CreateConnection();
            var result = await con.QueryAsync<Cliente>(query, new { @Id = Id });
            return result.FirstOrDefault();
        }, cancellationToken);

        return task == null ? throw new KeyNotFoundException($"Not Found Cliente with Id {Id}.") : task;
    }

    public async Task<bool> UpdateAsync(Cliente entity, long Id, CancellationToken cancellationToken = default)
    {
        var cliente = await GetEntityByIdAsync(Id, cancellationToken);
        if (cliente is not null)
        {
            var task = await Task.Run(async () =>
            {
                string sql = "UPDATE Clientes SET " +
                "Nombre = @Nombre, Apellido = @Apellido, Email = @Email, CiudadId = @CiudadId, UpdatedAt = @UpdatedAt, UpdatedBy = @UpdatedBy " +
                "WHERE Id = @Id;";
                using var con = _dbContext.CreateConnection();
                var result = await con.ExecuteAsync(sql, new
                {
                    @Nombre = entity.Nombre,
                    @Apellido = entity.Apellido,
                    @Email = entity.Email,
                    @CiudadId = entity.CiudadId,
                    @UpdatedAt = dateTimeService.NowUtc,
                    @UpdatedBy = 1, //Get data from UserServices from authenticated user,
                    @Id = Id
                });
                return result > 0;
            }, cancellationToken);
            return task;
        }
        return false;
    }
}
