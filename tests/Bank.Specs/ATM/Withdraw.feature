@ATM
Feature: Withdraw money
	In order to gain access to my money
	As an account owner
	I need to be able to withdraw money from my account balance

Scenario: Withdraw valid amount
	Given I am authenticated
	And I have a balance of "50"
	When I select Withdraw
	And I enter "20 "
	Then I should see "$20.00 has been withdrawn."

Scenario: Withdrawing to much should fail
	Given I am authenticated
	And I have a balance of "50"
	When I select Withdraw
	And I enter "60"
	Then I should see "Unable to withdraw that amount."

Scenario: Withdrawing negative amounts should fail
	Given I am authenticated
	When I select Withdraw
	And I enter "-10"
	Then I should see "Unable to withdraw that amount."