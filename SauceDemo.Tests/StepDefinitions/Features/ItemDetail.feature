Feature: Item Detail

    @page-navigation
    Scenario: Item Detail page displays correct item after selecting item name from Inventory
        Given I open the login page
        And I log in as "standard_user"
        When I click the "Sauce Labs Fleece Jacket" link
        Then the "item detail" page is displayed
        And the item detail product area displays the "Sauce Labs Fleece Jacket"

    @page-navigation
    Scenario: Item Detail page displays correct item after selecting image from Inventory 
        Given I open the login page
        And I log in as "standard_user"
        When I click the "Sauce Labs Onesie" image
        Then the "item detail" page is displayed
        And the item detail product area displays the "Sauce Labs Onesie"
        
    @page-navigation
    Scenario: Item Detail page displays correct item after selecting item name from Cart
        Given I open the login page
        And I log in as "standard_user"
        And I add "Sauce Labs Backpack" to the cart
        And I click the cart icon
        When I click the "Sauce Labs Backpack" link
        Then the "item detail" page is displayed
        And the item detail product area displays the "Sauce Labs Backpack"

    @reset-app-state @wip
    Scenario: Reset App State link reverts item state and cart icon count to defaults
    @cart-button-state @wip
    Scenario: Remove button displays Add to cart on Item Detail page after removing item from the cart
    @cart-button-state @wip
    Scenario: Add to cart button displays Remove on Item Detail page after adding from inventory
    @cart-button-state @wip
    Scenario: Add to cart button displays Add to cart on Item Detail page after removing from inventory
    @cart-button-state @wip
    Scenario: Item Detail page loads Remove button if item is already in cart on page load
