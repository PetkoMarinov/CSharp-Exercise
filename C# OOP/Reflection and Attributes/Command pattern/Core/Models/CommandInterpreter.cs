namespace CommandPattern
{
    using System;
    using System.Linq;
    using System.Reflection;
    using CommandPattern.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";

        public string Read(string input)
        {
            string commandName = input.Split()[0];
            string[] args = input.Split()[1..];

            // Retrieving a list in the form of an array of types (classes) of the calling assembly.
            var commandType = Assembly
            .GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(x => x.Name == $"{commandName}{CommandSuffix}");

            // Create an instance of the class whose name corresponds to the command
            // and convert to ICommand, because the Activator returns an object 
            // An activator is used when we do not know what the class name is
            // (what kind of class will be created).
            // Thats why the program reads information from the assembly itself. 
            ICommand command = (ICommand)Activator.CreateInstance(commandType);
            string result = command.Execute(args);
            return result;
        }
    }
}
