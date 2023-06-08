using SocioFormador.Domain.Common.Abstractions;

namespace SocioFormador.Domain.Entities;

public class Ciudad: EntityBase<long, long>
{
    public string Nombre { get; set; }
}
