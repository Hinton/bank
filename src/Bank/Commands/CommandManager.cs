using System.Collections.Generic;

namespace Bank.Commands
{
    public class CommandManager
    {

        private readonly Dictionary<string, Command> _commands;

        public CommandManager(Account account)
        {
            _commands = new Dictionary<string, Command>
            {
                ["withdraw"] = new Withdraw(account),
                ["balance"] = new Balance(account)
            };

        }

        public string Execute(string cmd)
        {
            return _commands[cmd]?.Execute();
        }
    }
}