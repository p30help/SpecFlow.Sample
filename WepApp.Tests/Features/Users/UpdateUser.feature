Feature: Update User

A short summary of the feature

@tag1
Scenario: Update a user
	Given a user with '1' as Id and 'mahdi' as username and 'ali radi' as fullname
	When create a request to update full name to 'mahdi radi' for user id '1'
	And call api
	Then status code is 200
	And fullname changed to 'mahdi radi' for user id '1'

@tag1
Scenario: Update a user with wrong id
	Given a user with '1' as Id and 'mahdi' as username and 'ali radi' as fullname
	When create a request to update full name to 'mahdi radi' for user id '2'
	And call api
	Then status code is 500
	And  exception thrown contain 'User not found' message

@tag1
Scenario: Update a user with empty full name
	Given a user with '1' as Id and 'mahdi' as username and 'ali radi' as fullname
	When create a request to update full name to '' for user id '1'
	And call api
	Then status code is 500
	And exception thrown contain 'Full Name must be filled' message