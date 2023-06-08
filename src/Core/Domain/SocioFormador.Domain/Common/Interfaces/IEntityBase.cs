
namespace SocioFormador.Domain.Common.Interfaces;

public interface IEntityBase<TKey, TUserKey>
{
    public TKey Id { get; set; }
    public TUserKey CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}
