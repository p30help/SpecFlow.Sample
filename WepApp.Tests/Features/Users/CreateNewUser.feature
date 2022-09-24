Feature: Create New User

A short summary of the feature

@tag1
Scenario: Create a user with empty username
	When create a request for user with '' as username and 'mahdi radi' as fullname
	And call api
	Then exception thrown contain 'Username must be filled' message

@tag1
Scenario: Create a user with empty fullname
	When create a request for user with 'mahdi' as username and '' as fullname
	And call api
	Then exception thrown contain 'Full Name must be filled' message

@tag1
Scenario: Create a user with username and fullname
	When create a request for user with 'mahdi' as username and 'mahdi radi' as fullname
	And call api
	Then status code is 200

@tag1
Scenario: must be complte
	Given have users like:
		| Email                   | Group Name | Group Id | Branch Name | Branch Id |
		| billjohnson@company.com | Group 1    | G 1 EXT  | Branch 1    | B 1 EXT   |
		| billjohnson@company.com | Group 2    | G 2 EXT  | Branch 3    | B 3 EXT   |
		| mary@company.com        | Group 2    | G 2 EXT  | Branch 3    | B 3 EXT   |
		| mary@company.com        | Group 3    | G 3 EXT  | Branch 2    | B 2 EXT   |
	When create a request for user with 'mahdi' as username and 'mahdi radi' as fullname
	And call api
	Then status code is 200


