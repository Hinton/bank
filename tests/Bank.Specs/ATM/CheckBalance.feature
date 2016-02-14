@ATM
Feature: Balance
	In order to know how much money I have
	As an account owner
	I need to be able check my account balance

Scenario: Get balance
	Given I am authenticated
	And I have a balance of "50"
	When I select Balance
	Then I should see "Your current balance is: $50.00."
