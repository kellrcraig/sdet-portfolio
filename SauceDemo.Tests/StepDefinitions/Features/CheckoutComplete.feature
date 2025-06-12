Feature: Checkout Complete

    @page-navigation
    Scenario: Back Home button navigates to Inventory page with empty cart
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                           | Order |
            | Sauce Labs Backpack               | 1     |
            | Sauce Labs Bolt T-Shirt           | 2     |
            | Test.allTheThings() T-Shirt (Red) | 3     |
            | Sauce Labs Onesie                 | 4     |
        And I click the cart icon
        And I click Checkout
        And I enter the following data:
            | Field      | Data     |
            | First Name | James    |
            | Last Name  | Howlett  |
            | Zip Code   | 77478    |
        And I click Continue
        And I click Finish
        When I click Back Home
        Then the "inventory" page is displayed
        And the cart badge is not displayed
    
    Scenario: Thank you message and confirmation icon are displayed
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                           | Order |
            | Sauce Labs Backpack               | 1     |
            | Sauce Labs Bolt T-Shirt           | 2     |
            | Test.allTheThings() T-Shirt (Red) | 3     |
            | Sauce Labs Onesie                 | 4     |
        And I click the cart icon
        And I click Checkout
        And I enter the following data:
            | Field      | Data     |
            | First Name | James    |
            | Last Name  | Howlett  |
            | Zip Code   | 77478    |
        And I click Continue
        When I click Finish
        Then the Thank You message is displayed