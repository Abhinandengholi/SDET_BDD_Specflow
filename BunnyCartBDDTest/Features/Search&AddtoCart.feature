Feature: Search&AddtoCart


@E2E-Search_AddtoCart
Scenario: Search & Add to Cart
	Given User will be on Homepage
	When User will type the '<searchtext>' in the searchbox
	Then Search Results are loaded in the same page with '<searchtext>'
	When User selects a '<productno>'
	Then Product page '<searchtext>' is loaded
	When User Will select quantity of the product
	* User add the product to  cart
	Then Product'<searchtext>' added to cart
	
Examples:
	| searchtext | productno |
	| Water      | 2	|
	


#@E2E-Search_AddtoCart
#Scenario: 02 Select a particular product
#	Given Search page is loaded
#	When User selects a '<productno>'
#	Then Product page is loaded
#
#Examples: 
#	| productno  |
#	| 1          |


