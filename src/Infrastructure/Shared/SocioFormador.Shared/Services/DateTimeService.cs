using SocioFormador.Domain.Interfaces;

namespace SocioFormador.Shared.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime NowUtc => DateTime.UtcNow;
}
