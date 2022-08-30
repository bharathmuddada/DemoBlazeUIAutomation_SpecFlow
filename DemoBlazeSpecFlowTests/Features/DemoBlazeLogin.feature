Feature: DemoBlaze Login Feature


Scenario: Login with empty credentials
	Given I navigate to the demoblaze website
	When I login with "empty" credentials
	Then No username and password alert should be displayed

Scenario: Login with invalid credentials
	Given I navigate to the demoblaze website
	When I login with "invalid" credentials
	Then Wrong password alert should be displayed

Scenario: Login with valid credentials
	Given I navigate to the demoblaze website
	When I login with "valid" credentials
	Then Login should be successfull


Scenario Outline: Login with different credentials
	Given I navigate to the demoblaze website
	When I login with '<username>' and '<password>'
	Then Outcome should match '<expected_result>'

	Examples: 
	| username       | password  | expected_result			  |
	|   			 |   		 | nousernamepasswordalert    |
	| AutomationUser | randompwd | wrongpassword			  |
	| AutomationUser | happy     | successfulllogin			  |