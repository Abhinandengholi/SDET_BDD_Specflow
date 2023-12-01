Feature: Login
User logs in with valid credentials(username, password)
Home page will load after successful login

Background: 
	Given User will be on the login page

@positive
Scenario: Login with Valid Credentials	
	When  User will enter username
	And   User will enter password
	And   User willl click on login button
	Then User will be redirected to Homepage
@negative
Scenario: Login with Invalid Credentials
	When  User will enter username
	And   User will enter password
	And   User willl click on login button
	Then Error message for Password Length should be thrown
@regression
Scenario: Check for Password Show Display
	When    User will enter password
	And   User willl click on Show Link in the password textbox
	Then the password character should be shown
@regression
Scenario: Check for Password Hidden Display
	When    User will enter password
	And   User willl click on Show Link in the password textbox
	And   User willl click on Hidden Link in the password textbox
	Then the password character should not be shown


