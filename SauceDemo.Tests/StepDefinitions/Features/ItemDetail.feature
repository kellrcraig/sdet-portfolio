@wip
Feature: Item Detail

    # Works from the image link and the name link. All properties from the selected item show up on the detail screen. Test multiple products.
    @page-navigation
    Scenario: Item Detail page displays correct item after selecting item name from Inventory
    @page-navigation
    Scenario: Item Detail page displays correct item after selecting image from Inventory    
        When I click the "Sauce Labs Backpack" image

    @page-navigation
    Scenario: Item Detail page displays correct item after selecting item name from Cart

    @reset-app-state
    Scenario: Reset App State link reverts item state and cart icon count to defaults
    @cart-button-state
    Scenario: Remove button displays Add to cart on Item Detail page after removing item from the cart
    @cart-button-state
    Scenario: Add to cart button displays Remove on Item Detail page after adding from inventory
    @cart-button-state
    Scenario: Add to cart button displays Add to cart on Item Detail page after removing from inventory
    @cart-button-state
    Scenario: Item Detail page loads Remove button if item is already in cart on page load
