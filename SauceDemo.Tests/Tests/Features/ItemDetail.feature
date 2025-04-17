Feature: Item Detail

    # Works from the image link and the name link. All properties from the selected item show up on the detail screen. Test multiple products.
    Scenario: Item detail page displays correct item after selecting from Inventory

    @reset-app-state
    Scenario: Reset App State link reverts item state and cart icon count to defaults
    @cart-button-state
    Scenario: Remove button displays Add to cart on item detail page after removing item from the cart
    @cart-button-state
    Scenario: Add to cart button displays Remove on item detail page after adding from inventory
    @cart-button-state
    Scenario: Add to cart button displays Add to cart on item detail page after removing from inventory
    @cart-button-state
    Scenario: Item detail page loads Remove button if item is already in cart on page load
