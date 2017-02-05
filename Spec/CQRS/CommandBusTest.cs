using System;
using Xunit;
using Moq;

using SimpleCQRS.CQRS;

namespace SimpleCQRS.Spec.CQRS
{
    public class CommandBusTest
    {
        ICommandBus commandBus;
        ICommandMessage command;
        Mock<IHandler<ICommandMessage>> handlerMock;
        IHandler<ICommandMessage> handler;

        public CommandBusTest() {
            commandBus = new CommandBus();

            Mock<ICommandMessage> commandMock = new Mock<ICommandMessage>();
            commandMock.Setup(c => c.GetType()).Returns(typeof (ICommandMessage));
            command = commandMock.Object;

            handlerMock = new Mock<IHandler<ICommandMessage>>();
            handler = handlerMock.Object;
        }

        [Fact]
        public void ShouldHandleTheCommandByPreviouslyRegisteredHandler()
        {
            commandBus.registerHandler<ICommandMessage>(handler);
            commandBus.handle(command);

            handlerMock.Verify(h => h.handle(command), Times.Once);
        }

        [Fact]
        public void ShouldThrowAnInvalidOperationExceptionWhenRegisterHandlerMoreThanOnce()
        {
            commandBus.registerHandler<ICommandMessage>(handler);

            Assert.Throws<InvalidOperationException>(() => {
                commandBus.registerHandler<ICommandMessage>(handler);
            });
        }

        [Fact]
        public void ShouldNotThrowAnyExceptionWhenCommandHandlerWasNotRegistered()
        {
            var exception = Record.Exception(() => commandBus.handle(command));

            Assert.Null(exception);
        }
    }
}
