namespace Wpm.SharedKernal
{
    public interface ICommandHandler<in T> where T : notnull
    {
        Task Handle(T command);
    }
}
