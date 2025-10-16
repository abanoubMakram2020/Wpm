using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Wpm.SharedKernal.ValueObjects
{
    public class StronglyTypedIdConverter<T> : ValueConverter<T, Guid>
        where T : ValueObjectId<T>
    {
        public StronglyTypedIdConverter()
            : base(
                id => id.Value,              // لما نحفظ
                value => ValueObjectId<T>.Create(value) // لما نقرأ
              )
        { }
    }

}
