Feature: Get User

A short summary of the feature

@tag1
Scenario: Get user by id
	Given a user with '1' as Id and 'mahdi' as username and 'mahdi radi' as fullname
	When get user with id '1'
	And call api
	Then status code is 200
	And user id is '1'

@tag1
Scenario: Get user by wrong id
	When get user with id '1'
	And call api
	Then status code is 204

@tag1
Scenario: Get user by username
	Given a user with '1' as Id and 'mahdi' as username and 'mahdi radi' as fullname
	When get user with username 'mahdi'
	And call api
	Then status code is 200

@tag1
Scenario: Get user by wong username
	When get user with username 'mahdi'
	And call api
	Then status code is 204
