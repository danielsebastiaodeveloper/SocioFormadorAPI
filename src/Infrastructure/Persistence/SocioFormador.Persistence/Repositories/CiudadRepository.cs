using Dapper;
using SocioFormador.Domain.Entities;
using SocioFormador.Domain.Interfaces.Repositories;
using SocioFormador.Persistence.Context;

namespace SocioFormador.Persistence.Repositories
{
    public class CiudadRepository : ICiudadRepository
    {
        private readonly SocioFormadorDapperDbContext _dbContext;

        public CiudadRepository(SocioFormadorDapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> CreateAsync(Ciudad entity, CancellationToken cancellationToken = default)
        {
            var task = await Task.Run(async () =>
            {
                string sql = "INSERT INTO Ciudades (Nombre, CreatedBy, CreatedAt) VALUES (@Nombre, @CreatedBy, @CreatedAt);";
                using var con = _dbContext.CreateConnection();
                var result = await con.ExecuteScalarAsync<long>(sql,
                    new
                    {
                        @Nombre = entity.Nombre,
                        @CreatedBy = 1,
                        @CreatedAt = DateTime.UtcNow
                    });
                return result;
            }, cancellationToken);

            return task;

        }

        public Task<bool> DeleteAsync(long Id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ciudad>> GetAllAsync(object? param = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Ciudad> GetEntityByIdAsync(long Id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Ciudad entity, long Id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
