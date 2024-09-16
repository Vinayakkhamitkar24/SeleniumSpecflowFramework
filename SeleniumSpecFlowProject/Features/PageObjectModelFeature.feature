Feature: PageObjectModelFeature

A short summary of the feature

@Sanity
Scenario: Page Object Model
	Given Enter youtube URL
	When Search for Testers Talk
	And  Navigate to channel
	Then Verify the title of page
