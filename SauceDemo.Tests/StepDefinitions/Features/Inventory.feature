Feature: Inventory

    Scenario: Inventory page loads with default items, sorting option, and empty cart
        Given I open the login page
        When I log in as "standard_user"
        Then the cart badge is not displayed
        And the sort dropdown displays "Name (A to Z)"
        And the inventory product area displays the following items:
            | Product                           | Order |
            | Sauce Labs Backpack               | 1     |
            | Sauce Labs Bike Light             | 2     |
            | Sauce Labs Bolt T-Shirt           | 3     |
            | Sauce Labs Fleece Jacket          | 4     |
            | Sauce Labs Onesie                 | 5     |
            | Test.allTheThings() T-Shirt (Red) | 6     |

    Scenario: Sorting by Name (A to Z) orders items alphabetically
        Given I open the login page
        And I log in as "standard_user"
        When I sort by "Name (Z to A)" 
        And I sort by "Name (A to Z)"
        Then the inventory product area displays the following items:
            | Product                           | Order |
            | Sauce Labs Backpack               | 1     |
            | Sauce Labs Bike Light             | 2     |
            | Sauce Labs Bolt T-Shirt           | 3     |
            | Sauce Labs Fleece Jacket          | 4     |
            | Sauce Labs Onesie                 | 5     |
            | Test.allTheThings() T-Shirt (Red) | 6     |      

    Scenario: Sorting by Name (Z to A) orders items in reverse alphabetical order
        Given I open the login page
        And I log in as "standard_user"
        When I sort by "Name (Z to A)"
        Then the inventory product area displays the following items:
            | Product                           | Order |
            | Sauce Labs Backpack               | 6     |
            | Sauce Labs Bike Light             | 5     |
            | Sauce Labs Bolt T-Shirt           | 4     |
            | Sauce Labs Fleece Jacket          | 3     |
            | Sauce Labs Onesie                 | 2     |
            | Test.allTheThings() T-Shirt (Red) | 1     |

    Scenario: Sorting by Price (low to high) orders items from cheapest to most expensive
        Given I open the login page
        And I log in as "standard_user"
        When I sort by "Price (low to high)"
        Then the inventory product area displays the following items:
            | Product                           | Order |
            | Sauce Labs Backpack               | 5     |
            | Sauce Labs Bike Light             | 2     |
            | Sauce Labs Bolt T-Shirt           | 3     |
            | Sauce Labs Fleece Jacket          | 6     |
            | Sauce Labs Onesie                 | 1     |
            | Test.allTheThings() T-Shirt (Red) | 4     |

    Scenario: Sorting by Price (high to low) orders items from most to least expensive
        Given I open the login page
        And I log in as "standard_user"
        When I sort by "Price (high to low)"
        Then the inventory product area displays the following items:
            | Product                           | Order |
            | Sauce Labs Backpack               | 2     |
            | Sauce Labs Bike Light             | 5     |
            | Sauce Labs Bolt T-Shirt           | 3     |
            | Sauce Labs Fleece Jacket          | 1     |
            | Sauce Labs Onesie                 | 6     |
            | Test.allTheThings() T-Shirt (Red) | 4     |

    @wip
    Scenario: Add to cart button increases cart badge count
    @wip
    Scenario: Remove button decreases cart badge count

    @page-navigation @wip
    Scenario: Back to products link navigates from the Item detail screen to Inventory page

    @cart-button-state @wip
    Scenario: Remove button displays Add to cart after removing item from the cart
    @cart-button-state @wip
    Scenario: Add to cart button displays Remove on Inventory page after adding from item detail
    @cart-button-state @wip
    Scenario: Add to cart button displays Add to cart on Inventory page after removing from item detail
