namespace Wpm.SharedKernal.ValueObjects
{
    public abstract record ValueObjectId<T>(Guid Value)
    {
        public static T Create(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentNullException(nameof(value), $"{typeof(T).Name} is not valid.");

            return (T)Activator.CreateInstance(typeof(T), value)!;
        }

        public static implicit operator Guid(ValueObjectId<T> id) => id.Value;
    }

}
