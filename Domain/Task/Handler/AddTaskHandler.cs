using System;

using Domain.Task.Command;

namespace Domain.Task.Handler
{
    public class AddTaskHandler : CQRS.IHandler<AddTask>
    {

        public void handle(AddTask command) {
            var task = new Entity.Task(command.name, command.description);

            Console.WriteLine("Created task: {0}", task.name);
        }

    }
}
