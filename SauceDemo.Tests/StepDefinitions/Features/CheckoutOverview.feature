Feature: Checkout: Overview

    @page-navigation
    Scenario: Cancel button navigates to Checkout: Your Information page
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
        When I click Cancel
        Then the "inventory" page is displayed

    @page-navigation
    Scenario: Finish button navigates to Checkout: Complete page
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
        Then the "checkout complete" page is displayed
    

    @cart-contents
    Scenario: Cart list displays all added items
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                           | Order |
            | Sauce Labs Bolt T-Shirt           | 1     |
            | Sauce Labs Bike Light             | 2     |
            | Test.allTheThings() T-Shirt (Red) | 3     |
        And I click the cart icon
        And I click Checkout
        And I enter the following data:
            | Field      | Data     |
            | First Name | James    |
            | Last Name  | Howlett  |
            | Zip Code   | 77478    |
        When I click Continue
        Then the checkout product area displays the following items:
            | Product                           | Order |
            | Sauce Labs Bolt T-Shirt           | 1     |
            | Sauce Labs Bike Light             | 2     |
            | Test.allTheThings() T-Shirt (Red) | 3     |

    Scenario: Payment information section displays correct text
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                           | Order |
            | Sauce Labs Bolt T-Shirt           | 1     |
            | Sauce Labs Bike Light             | 2     |
            | Test.allTheThings() T-Shirt (Red) | 3     |
        And I click the cart icon
        And I click Checkout
        And I enter the following data:
            | Field      | Data     |
            | First Name | James    |
            | Last Name  | Howlett  |
            | Zip Code   | 77478    |
        When I click Continue
        Then the payment information displays

    Scenario: Shipping information section displays correct text
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                           | Order |
            | Sauce Labs Bolt T-Shirt           | 1     |
            | Sauce Labs Bike Light             | 2     |
            | Test.allTheThings() T-Shirt (Red) | 3     |
        And I click the cart icon
        And I click Checkout
        And I enter the following data:
            | Field      | Data     |
            | First Name | James    |
            | Last Name  | Howlett  |
            | Zip Code   | 77478    |
        When I click Continue
        Then the shipping information displays

    Scenario: Price Total is calculated correctly
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                           | Order |
            | Sauce Labs Bolt T-Shirt           | 1     |
            | Sauce Labs Bike Light             | 2     |
            | Test.allTheThings() T-Shirt (Red) | 3     |
        And I click the cart icon
        And I click Checkout
        And I enter the following data:
            | Field      | Data     |
            | First Name | James    |
            | Last Name  | Howlett  |
            | Zip Code   | 77478    |
        When I click Continue
        Then the item total displays "Item total: $41.97"
        And the tax displays "Tax: $3.36"
        And the total displays "Total: $45.33"