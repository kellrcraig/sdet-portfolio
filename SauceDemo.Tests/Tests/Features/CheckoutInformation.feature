Feature: Checkout: Your Information

    Scenario: Zip code field only accepts standard US format (five digits (e.g., 90210) or nine digits with dash (e.g., 90210-1234))
    Scenario: Name fields accept alphabetic characters
    Scenario: Name fields accept hyphens and apostrophes
    Scenario: Name fields accept names with spaces
    Scenario: Name fields accept names with Unicode characters
    Scenario: Name fields reject inputs longer than 50 characters
    Scenario: Name fields warns for numbers but does not block submission
    Scenario: Tab key navigates to the next field
    Scenario: Shift+tab navigates to the previous field
    Scenario: Continue button navigates to Checkout: Overview page after validation succeeds

    #This scenario will validate that the three fields have a non-zero character count
    Scenario: Continue button does not navigate after validation fails

    Scenario: Validation error is cleared after closing the message
    Scenario: Cancel button navigates to Your Cart page
    Scenario: Cannot access Checkout: Your Information page via direct URL
