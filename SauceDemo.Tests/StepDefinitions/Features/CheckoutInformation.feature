Feature: Checkout: Your Information

    Scenario: Tab key navigates to the next field
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                           | Order |
            | Sauce Labs Backpack               | 1     |
            | Sauce Labs Fleece Jacket          | 2     |
            | Test.allTheThings() T-Shirt (Red) | 3     |
            | Sauce Labs Onesie                 | 4     |
        And I click the cart icon
        And I click Checkout
        And I click the "First Name" field
        And the active field is "First Name"
        When I press the Tab key
        Then the active field is "Last Name"

    Scenario: Shift+tab navigates to the previous field
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                           | Order |
            | Sauce Labs Backpack               | 1     |
            | Sauce Labs Fleece Jacket          | 2     |
            | Test.allTheThings() T-Shirt (Red) | 3     |
            | Sauce Labs Onesie                 | 4     |
        And I click the cart icon
        And I click Checkout
        And I click the "Zip Code" field
        And the active field is "Zip Code"
        When I press the Shift+Tab keys
        Then the active field is "Last Name"

    Scenario: Continue button blocks page navigation when all fields are empty
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
        When I click Continue
        Then the "checkout information" page is displayed
        And the "Error: First Name is required" form error message is displayed
        And all fields display error styling


    Scenario: Continue button blocks page navigation when First Name field is empty
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
            | First Name |          |
            | Last Name  | Howlett  |
            | Zip Code   | 77478    |
        And the form displays the following data:
            | Field      | Data     |
            | First Name |          |
            | Last Name  | Howlett  |
            | Zip Code   | 77478    |
        When I click Continue
        Then the "checkout information" page is displayed
        And the "Error: First Name is required" form error message is displayed
        And all fields display error styling

    Scenario: Continue button blocks page navigation when Last Name field is empty
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
            | Last Name  |          |
            | Zip Code   | 77478    |
        And the form displays the following data:
            | Field      | Data     |
            | First Name | James    |
            | Last Name  |          |
            | Zip Code   | 77478    |
        When I click Continue
        Then the "checkout information" page is displayed
        And the "Error: Last Name is required" form error message is displayed
        And all fields display error styling

    Scenario: Continue button blocks page navigation when Postal Code field is empty
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
            | Zip Code   |          |
        And the form displays the following data:
            | Field      | Data     |
            | First Name | James    |
            | Last Name  | Howlett  |
            | Zip Code   |          |
        When I click Continue
        Then the "checkout information" page is displayed
        And the "Error: Postal Code is required" form error message is displayed
        And all fields display error styling

    Scenario: Validation error is cleared after closing the message
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
            | Zip Code   |          |
        And I click Continue
        And the "Error: Postal Code is required" form error message is displayed
        When I dismiss the form error message
        Then no fields display error styling

    @page-navigation
    Scenario: Continue button navigates to Checkout: Overview page after validation succeeds
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
        When I click Continue
        Then the "checkout overview" page is displayed 

    @page-navigation
    Scenario: Cancel button navigates to Your Cart page
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
        When I click Cancel
        Then the "cart" page is displayed