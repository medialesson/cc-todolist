using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Data;
using Xunit;

namespace TodoList.Tests
{
    public class CommandsUnitTest
    {
        [Fact]
        public void ShouldAddCommandAndExecuteWithResult()
        {
            // Set up command
            string test = "";
            var command = new Command("test", (() => { test = "test command"; }));

            // Execute
            command.Action.Invoke();

            // Assert
            Assert.Equal("test command", test);
        }
    }
}
