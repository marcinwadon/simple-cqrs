using System;

using Domain.Task.Command;
using Domain.Task.Handler;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // From DI:
            var commandBus = new CQRS.CommandBus();

            // In setup:
            commandBus.registerHandler<AddTask>(new AddTaskHandler());

            var command = new AddTask("Task name", "Task description");
            commandBus.handle(command);
        }
    }
}
