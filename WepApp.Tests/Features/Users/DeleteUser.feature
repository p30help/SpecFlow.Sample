Feature: Delete User

A short summary of the feature

@tag1
Scenario: Delete a user
	Given a user with '1' as Id and 'mahdi' as username and 'ali radi' as fullname
	When create a request to delete user id '1'
	And call api
	Then status code is 200
	And user id '1' is not found

@tag1
Scenario: Delete a user with wrong id
	Given a user with '1' as Id and 'mahdi' as username and 'ali radi' as fullname
	When create a request to delete user id '2'
	And call api
	Then status code is 500
	And exception thrown contain 'User not found' message