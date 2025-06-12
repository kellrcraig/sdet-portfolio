@known-issues
Feature: Known Issues

    @reset-app-state
    Scenario: Reset App State link reverts items, sorting option, and cart badge count to defaults
    @reset-app-state
    Scenario: Resetting App State clears all items from the cart    
    Scenario: Items and sorting option persist when returning to Inventory page

    #If navigated from Inventory Detail, returns there; otherwise returns to Inventory
    @page-navigation
    Scenario: Continue Shopping button navigates back to previous page
    @page-navigation
    Scenario: Checkout button navigates to Checkout: Your Information page when the cart is not empty
    @page-navigation
    Scenario: Checkout button does not navigate when the cart is empty

    Scenario: Zip code field only accepts standard US format (five digits (e.g., 90210) or nine digits with dash (e.g., 90210-1234))
    Scenario: Name fields accept alphabetic characters
    Scenario: Name fields accept hyphens and apostrophes
    Scenario: Name fields accept names with spaces
    Scenario: Name fields accept names with Unicode characters
    Scenario: Name fields reject inputs longer than 50 characters
    Scenario: Name fields warns for numbers but does not block submission
    Scenario: Cannot access Checkout: Your Information page via direct URL    
    Scenario: Cannot access Checkout: Overview page via direct URL
    Scenario: Cannot access Checkout: Complete page via direct URL
    Scenario: User who is actively using the app is not automatically logged out after 10 minutes