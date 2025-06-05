Feature: Checkout: Overview

    #This button behaves inconsistently with the Checkout: Your Information page. 
    #The Checkout: Your Information page navigates to the previous page back, but this Cancel button brings you all the way back to the Inventory page
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
    

    @cart-contents @wip
    #assert that the correct items appears, their name, description, price, quantity, and order.
    Scenario: Cart list displays all added items

    @wip
    #SauceCard #31337
    Scenario: Payment information section displays correct text

    @wip
    #Free Pony Express Delivery!
    Scenario: Shipping information section displays correct text	

    @wip
    #values based on the items you have in your cart. Is tax based on a percentage?
    Scenario: Price Total is calculated correctly
    
    @wip
    Scenario: Cannot access Checkout: Overview page via direct URL
