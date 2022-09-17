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


