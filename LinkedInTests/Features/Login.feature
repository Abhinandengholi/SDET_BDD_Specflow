Feature: Login
User logs in with valid credentials(username, password)
Home page will load after successful login

Background: 
	Given User will be on the login page

@positive
Scenario Outline: Login with Valid Credentials	
	When  User will enter username '<UserName>'
	And   User will enter password '<Password>'
	And   User willl click on login button
	Then User will be redirected to Homepage
Examples: 
| UserName    | Password |
| abc@xyz.com | 12344    |
| def@wer.com | 67899    |
	
@negative
Scenario Outline: Login with Invalid Credentials
	When  User will enter username '<UserName>'
	And   User will enter password '<Password>'
	And   User willl click on login button
	Then Error message for Password Length should be thrown
Examples: 
| UserName    | Password |
| abc@xyz.com | 12344    |
| def@wer.com | 67899    |
@regression
Scenario Outline: Check for Password Show Display
	When  User will enter password '<Password>'
	And   User willl click on Show Link in the password textbox
	Then the password character should be shown
Examples: 
| Password |
| 12344    |
| 67899    |
@regression
Scenario Outline: Check for Password Hidden Display
	When  User will enter password '<Password>'
	And   User willl click on Show Link in the password textbox
	And   User willl click on Hidden Link in the password textbox
	Then the password character should not be shown
Examples: 
| Password |
| 12344    |
| 67899    |


