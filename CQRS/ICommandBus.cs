namespace CQRS
{
    public interface ICommandBus
    {
        void registerHandler<TCommand>(IHandler<TCommand> handler) where TCommand : class, ICommandMessage;
        void handle(ICommandMessage command);
    }
}
