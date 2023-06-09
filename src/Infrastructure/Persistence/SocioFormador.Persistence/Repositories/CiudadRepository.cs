using Dapper;
using SocioFormador.Domain.Entities;
using SocioFormador.Domain.Interfaces;
using SocioFormador.Domain.Interfaces.Repositories;
using SocioFormador.Persistence.Context;

namespace SocioFormador.Persistence.Repositories
{
    public class CiudadRepository : ICiudadRepository
    {
        private readonly SocioFormadorDapperDbContext _dbContext;
        private readonly IDateTimeService dateTimeService;

        public CiudadRepository(SocioFormadorDapperDbContext dbContext, IDateTimeService dateTimeService)
        {
            _dbContext = dbContext;
            this.dateTimeService = dateTimeService;
        }

        public async Task<long> CreateAsync(Ciudad entity, CancellationToken cancellationToken = default)
        {
            var task = await Task.Run(async () =>
            {
                string sql = "INSERT INTO Ciudades (Nombre, CreatedBy, CreatedAt) VALUES (@Nombre, @CreatedBy, @CreatedAt); SELECT LAST_INSERT_ID();";
                using var con = _dbContext.CreateConnection();
                var result = await con.ExecuteScalarAsync<long>(sql,
                    new
                    {
                        @Nombre = entity.Nombre,
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
                    string sql = "DELETE FROM Ciudades WHERE Id = @Id";
                    using var con = _dbContext.CreateConnection();
                    var result = await con.ExecuteAsync(sql, new { @Id = Id });
                    return result > 0;
                }, cancellationToken);
                return task;
            }
            return false;
        }

        public async Task<IEnumerable<Ciudad>> GetAllAsync(object? param = null, CancellationToken cancellationToken = default)
        {
            var task = await Task.Run(async () =>
            {
                string query = "SELECT Id, Nombre FROM Ciudades;";
                using var con = _dbContext.CreateConnection();
                var result = await con.QueryAsync<Ciudad>(query);
                return result;
            }, cancellationToken);

            return task;
        }

        public async Task<Ciudad> GetEntityByIdAsync(long Id, CancellationToken cancellationToken = default)
        {
            var task = await Task.Run(async () =>
            {
                string query = "SELECT Id, Nombre FROM Ciudades WHERE Id = @Id;";
                using var con = _dbContext.CreateConnection();
                var result = await con.QueryAsync<Ciudad>(query, new { @Id = Id });
                return result.FirstOrDefault();
            }, cancellationToken);

            return task == null ? throw new KeyNotFoundException($"Not Found Ciudad with Id {Id}.") : task;
        }

        public async Task<bool> UpdateAsync(Ciudad entity, long Id, CancellationToken cancellationToken = default)
        {
            var ciudad = await GetEntityByIdAsync(Id, cancellationToken);

            if (ciudad is not null)
            {
                var task = await Task.Run(async () =>
                {
                    string sql = "UPDATE Ciudades SET Nombre = @Nombre WHERE Id = @Id;";
                    using var con = _dbContext.CreateConnection();
                    var result = await con.ExecuteAsync(sql, new
                    {
                        @Nombre = entity.Nombre,
                        @Id = Id
                    });

                    return result > 0;

                }, cancellationToken);

                return task;
            }
            return false;
        }
    }
}
