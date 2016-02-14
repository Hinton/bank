using System;

namespace Bank.Commands
{
    internal class Withdraw : Command
    {
        public Withdraw(Account account) : base(account)
        {
        }

        public override string Execute()
        {
            Console.WriteLine("How much money would you like to withdraw?");
            int amount = Convert.ToInt32(Console.ReadLine());

            Money am = new Money(amount);

            try
            {
                _account.Withdraw(am);
                return am + " has been withdrawn.";
            }
            catch (Exception)
            {
                return "Unable to withdraw that amount.";
            }
        }
    }
}