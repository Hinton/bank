namespace Bank.Commands
{
    internal class Balance : Command
    {
        public Balance(Account account) : base(account)
        {
        }

        public override string Execute()
        {
            return "Your current balance is: " + _account.Balance + ".";
        }
    }
}