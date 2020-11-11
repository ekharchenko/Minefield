using MineField.Engine;
using MineField.Engine.Commands;
using MineField.Engine.View;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MineField.Tests.Engine.Commands
{
    public class ArrowUpCommandTests
    {
        private Mock<IView> _viewMock;
        private ICommand command;

        [SetUp]
        public void Setup()
        {
            _viewMock = new Mock<IView>();

            command = new ArrowUpCommand(_viewMock.Object);
        }

        [Test]
        public void Execute_GivenStartPoint_ShouldNotChangeStateAndCallRender()
        {
            //Mock
            GameState state = new GameState();

            //Run Test
            command.Execute(state);

            //Verify
            _viewMock.Verify(m => m.Render(It.IsAny<GameState>()), Times.Once);
            Assert.AreEqual(state.Actions.Count, 1);
        }

        [Test]
        public void Execute_GivenPoint10_ShouldChangeStateToPoint00AndCallRender()
        {
            //Mock
            GameState state = new GameState();
            state.Actions.Push(new Tuple<int, int>(1, 0));

            //Run Test
            command.Execute(state);

            //Verify
            _viewMock.Verify(m => m.Render(It.IsAny<GameState>()), Times.Once);
            Assert.AreEqual(state.Actions.Peek(), new Tuple<int, int>(0, 0));
            Assert.AreEqual(state.Actions.Count, 3);
        }

        [Test]
        public void Execute_GivenPoint22AndRendersMethodThrowsInvalidOperationException_ShouldThrowInvalidOperationException()
        {
            //Mock
            GameState state = new GameState();
            state.Actions.Push(new Tuple<int, int>(2, 2));
            _viewMock.Setup(m => m.Render(It.IsAny<GameState>())).Throws<InvalidOperationException>();

            //Run and Verify
            Assert.Throws<InvalidOperationException>(() => command.Execute(state));
        }
    }
}
