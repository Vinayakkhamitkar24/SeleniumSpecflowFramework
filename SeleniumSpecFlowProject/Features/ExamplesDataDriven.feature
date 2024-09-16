Feature: Example DataDriven

A short summary of the feature

@Sanity
Scenario Outline: Examples Search Text DataDriven
	Given Open Browser
	When Enter the URL
	Then Search Text <SearchKey>

	Examples: 
	| SearchKey                |
	| Specflow by Testers Talk |
	| Selenium by Testers Talk |
