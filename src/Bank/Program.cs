using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine("Welcome to C# ATM Service!\n");

			Account a = new Account(new Money(50));

			while (true)
			{
				// TODO: Split out into a Console Manager?
				// List of Commands?
				Console.WriteLine("1. View current balance.");
				Console.WriteLine("2. Withdraw.");
				Console.WriteLine("3. Exit.");
				Console.WriteLine("");

				int choice = Convert.ToInt32(Console.ReadLine());
				
				// RunCommand(cmd)?
				switch (choice)
				{
					case 1: // Print current balance
						Console.WriteLine("Your currnet balance is: " + a.Balance + ".");
						break;
					case 2:
						Console.WriteLine("How much money would you like to withdraw?");
						int amount = Convert.ToInt32(Console.ReadLine());

						Money am = new Money(amount);

						try
						{
							a.Withdraw(am);
							Console.WriteLine(am + " has been withdrawn.");
						}
						catch (Exception)
						{
							Console.WriteLine("Unable to withdraw that amount.");
						}
                        break;
					case 3: // Terminate program
						System.Environment.Exit(0);
						break;
				}
				Console.WriteLine("");


			}


		}
	}
}
