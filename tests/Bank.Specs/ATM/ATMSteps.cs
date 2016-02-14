using System;
using System.Diagnostics;
using System.IO;
using TechTalk.SpecFlow;
using Xunit;

namespace Bank.Specs.ATM
{
    [Binding]
    public class ATMSteps
    {

        private static TextWriter _consoleWriter;

        private static TextWriter _oldWriter;
        private static TextReader _oldReader;

        private static string _input;

        private Bank.ATM _atm;
        private string _result;

        [BeforeScenario("ATM")]
        public static void BeforeScenario()
        {
            _oldWriter = Console.Out;
            _oldReader = Console.In;

            _consoleWriter = new StringWriter();
            _input = "";
            Console.SetOut(_consoleWriter);
        }

        [AfterScenario("ATM")]
        public static void AfterScenario()
        {
            Console.SetOut(_oldWriter);
            Console.SetIn(_oldReader);
        }

        [Given(@"I am authenticated")]
        public void GivenIAmAuthenticated()
        {
            _atm = new Bank.ATM(new Account(new Money(50)));
        }
        
        [When(@"I enter ""(.*)""")]
        public void WhenIEnter(int p0)
        {
            _input += p0 + "\n";
        }
        
        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string p0)
        {
            _input += "3\n";
            Console.SetIn(new StringReader(_input));

            _atm.Run();

            var result = _consoleWriter.ToString()
                .Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // Ensure the string exists
            Assert.Contains(p0, result);
        }

        [Given(@"I have a balance of ""(.*)""")]
        public void GivenIHaveABalanceOf(int p0)
        {
            _atm = new Bank.ATM(new Account(new Money(p0)));
        }

        [When(@"I select Withdraw")]
        public void WhenISelectWithdraw()
        {
            _input += "2\n";
        }

        [When(@"I select Balance")]
        public void WhenISelectBalance()
        {
            _input += "1\n";
        }


    }
}
