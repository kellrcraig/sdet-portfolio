Feature: Your Cart
    
    @page-navigation
    Scenario: Continue Shopping button navigates back to inventory page
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                           |
            | Sauce Labs Backpack               |
            | Sauce Labs Fleece Jacket          |
            | Test.allTheThings() T-Shirt (Red) |
        And I click the cart icon
        When I click Continue Shopping
        Then the "inventory" page is displayed

    @page-navigation
    Scenario: Checkout button navigates to Checkout: Your Information page
        Given I open the login page
        And I log in as "standard_user"
        And I add the following items to the cart:
            | Product                           |
            | Sauce Labs Onesie                 |
            | Sauce Labs Fleece Jacket          |
            | Test.allTheThings() T-Shirt (Red) |
        And I click the cart icon
        When I click Checkout
        Then the "checkout information" page is displayed

    @cart-contents @wip
    Scenario: Cart displays empty when there are no items in it
    @cart-contents @wip
    Scenario: Remove button removes item from cart
    
    @cart-contents @wip
    #assert that the correct items appears, their name, description, price, quantity, and order.
    Scenario: Cart displays all added items

    @cart-contents @wip
    Scenario: Cart displays previously added items after logout

    #This scenario is intended to assert the initial state of the cart button after a direct nav (e.g., deep linking, or returning to the item from history). 
    #This is intended to simulate a persisted state across sessions and a non-contiguous navigation path like you suggested on the other .feature file.
    @cart-contents @wip
    Scenario: Cart displays correct contents after returning via direct URL

    @reset-app-state @wip
    Scenario: Resetting App State clears all items from the cart