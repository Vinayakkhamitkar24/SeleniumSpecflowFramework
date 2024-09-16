Feature: EcommerceEndToEnd

A short summary of the feature

@E2E
Scenario: Purchase product
	Given I am on product page
	When  Add product to cart
	And   check product Added to cart
	And   Complete product purchase
	Then  Verify Product purchased sucessfully
