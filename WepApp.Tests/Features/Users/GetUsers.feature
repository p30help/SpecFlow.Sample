Feature: Get Users

A short summary of the feature

@tag1
Scenario: Get list of users
	Given list of users:
		| Id                                   | Username | FullName | Gender |
		| 4a8278ec-e53a-4ce7-8b02-ff37ccd6b507 | user1    | james    | male   |
		| 13233f9f-8127-4f48-bf21-1f969daa7cc3 | user2    | mahdi    | male   |
		| 1c83f84d-2063-4d9f-b790-3fa5f0fab5ca | user3    | fati     | female |
		| bc1ca018-67fd-4ef7-9820-ab2c4e945143 | user4    | vort     |        |
	When get users
	And call api
	Then status code is 200
	And response body is like 'users.json'