Feature: Login

@WebApp
Scenario: Verify login
	Given I navigate to ClickUp
	When I set '[UserName]' in UserName on Login
		And I set '[Password]' in Password 
		And I click Login
	Then I should see 'View' displayed on Home
