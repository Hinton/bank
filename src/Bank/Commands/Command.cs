namespace Bank.Commands
{
    internal abstract class Command
    {
        protected readonly Account _account;

        public Command(Account account)
        {
            _account = account;
        }

        public abstract string Execute();

    }
}