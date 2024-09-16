Feature: Search Feature

A short summary of the feature

@Sanity
Scenario: Search with Text
	Given Open Browser
	When Enter the URL
	Then Search Text

@Sanity
Scenario: Search Text and verify Title
	Given Open Browser
	When Enter the URL
	Then Search Text
	And Verify Page Title

	
