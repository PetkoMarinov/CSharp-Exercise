namespace CommandPattern
{
    using CommandPattern.Core.Contracts;
    using CommandPattern.Core.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            //Creating an empty instances of CommandInterpreter and Engine

            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}
