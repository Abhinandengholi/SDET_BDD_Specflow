Feature: Search



@Product_Search
Scenario Outline: Search For Products 
	Given User Will be on the Homepage
	When User will type the '<searchtext>' in the searchbox
	Then Search results are loaded in the same page with '<searchtext>'
Examples: 
	| searchtext | 
	| water      |         
	| java       |         
	| hairgrass  |         
