using System;
using Bank.Commands;

namespace Bank
{
	public class ATM
	{

	    private Account _account;
	    private CommandManager _commandManager;

	    public ATM(Account a)
	    {
            Console.WriteLine("Welcome to C# ATM Service!\n");

	        _account = a;
            _commandManager = new CommandManager(a);
	    }

	    public void Run()
	    {
            while (true)
            {
                PrintHelp();

                int choice = Convert.ToInt32(Console.ReadLine());
                if (RunCommand(choice))
                {
                    return;
                }

                Console.WriteLine("");
            }
        }

	    public bool RunCommand(int choice)
	    {
	        string cmd = "";
            switch (choice)
            {
                case 1:
                    cmd = "balance";
                    break;
                case 2:
                    cmd = "withdraw";
                    break;
                case 3: // Terminate program
                    return false;
                    break;
            }

	        Console.WriteLine(_commandManager.Execute(cmd));
	        return true;
	    }

	    public void PrintHelp()
	    {
            Console.WriteLine("1. View current balance.");
            Console.WriteLine("2. Withdraw.");
            Console.WriteLine("3. Exit.");
            Console.WriteLine("");
        }

	    static void Main(string[] args)
		{
            var atm = new ATM(new Account(new Money(50)));
	        atm.Run();
		}
	}
}
