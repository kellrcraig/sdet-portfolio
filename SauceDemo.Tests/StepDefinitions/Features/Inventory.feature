@wip
Feature: Inventory

    Scenario: Inventory page loads with default items, sorting option, and empty cart
    Scenario: Sorting by Name (A to Z) orders items alphabetically
    Scenario: Sorting by Name (Z to A) orders items in reverse alphabetical order
    Scenario: Sorting by Price (low to high) orders items from cheapest to most expensive
    Scenario: Sorting by Price (high to low) orders items from most to least expensive
    Scenario: Add to cart button updates cart icon count
    Scenario: Remove button updates cart icon count
    @page-navigation
    Scenario: Back to products link navigates from the Item detail screen to Inventory page
    @reset-app-state
    Scenario: Reset App State link reverts items, sorting option, and cart icon count to defaults
    Scenario: Items and sorting option persist when returning to Inventory page
    @cart-button-state
    Scenario: Remove button displays Add to cart after removing item from the cart
    @cart-button-state
    Scenario: Add to cart button displays Remove on Inventory page after adding from item detail
    @cart-button-state
    Scenario: Add to cart button displays Add to cart on Inventory page after removing from item detail
