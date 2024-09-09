using CarManager.Domain.ValueObjects;
using Mapster;

namespace CarManager.Application.Mapster.Mappers;

public class SingleValueObjectsMapper : IRegister
{
    void IRegister.Register(TypeAdapterConfig config)
    {
        config.ForType<SingleValueObject<Guid>, Guid>().MapWith(src => src == null ? default : src.Value);
        config.ForType<SingleValueObject<string>, string>().MapWith(src => src == null ? default! : src.Value);
        config.ForType<SingleValueObject<int>, int>().MapWith(src => src == null ? default : src.Value);
    }
}
