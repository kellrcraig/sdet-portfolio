Feature: Your Cart

    @reset-app-state
    Scenario: Resetting App State clears all items from the cart
    
    #If navigated from Inventory Detail, returns there; otherwise returns to Inventory
    Scenario: Continue Shopping button navigates back to previous page

    Scenario: Checkout button navigates to Checkout: Your Information page when the cart is not empty
    Scenario: Checkout button does not navigate when the cart is empty
    @cart-contents
    Scenario: Cart displays empty when there are no items in it
    @cart-contents
    Scenario: Remove button removes item from cart
    
    @cart-contents
    #assert that the correct items appears, their name, description, price, quantity, and order.
    Scenario: Cart displays all added items

    @cart-contents
    Scenario: Cart displays previously added items after logout

    #This scenario is intended to assert the initial state of the cart button after a direct nav (e.g., deep linking, or returning to the item from history). 
    #This is intended to simulate a persisted state across sessions and a non-contiguous navigation path like you suggested on the other .feature file.
    @cart-contents
    Scenario: Cart displays correct contents after returning via direct URL
