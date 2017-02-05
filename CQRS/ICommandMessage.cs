namespace SimpleCQRS.CQRS
{
    public interface ICommandMessage
    {
         string message { get; }
         System.Type GetType();
    }
}
