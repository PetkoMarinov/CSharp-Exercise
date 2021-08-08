namespace CommandPattern.Core.Models
{
    using CommandPattern.Core.Contracts;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return null;
        }
    }
}
