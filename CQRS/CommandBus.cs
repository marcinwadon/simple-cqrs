using System;
using System.Collections.Generic;

namespace SimpleCQRS.CQRS
{
    public class CommandBus : ICommandBus
    {
        private readonly Dictionary<Type, Action<ICommandMessage>> _handlers = new Dictionary<Type, Action<ICommandMessage>>();

        public void registerHandler<TCommand>(IHandler<TCommand> handler) where TCommand : class, ICommandMessage {
            var type = typeof (TCommand);
            if (_handlers.ContainsKey(type)) {
                throw new InvalidOperationException(string.Format("Handler exists for type {0}.", type));
            }

            _handlers[type] = command => handler.handle((TCommand)command);
        }

        public void handle(ICommandMessage command) {
            var type = command.GetType();

            if (!_handlers.ContainsKey(type)) {
                return;
            }

            var handler = _handlers[type];
            handler(command);
        }
    }
}
