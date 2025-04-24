@wip
Feature: Checkout: Overview

    #This button behaves inconsistently with the Checkout: Your Information page. 
    #The Checkout: Your Information page navigates to the previous page back, but this Cancel button brings you all the way back to the Products page
    @page-navigation
    Scenario: Cancel button navigates to Checkout: Your Information page

    @page-navigation
    Scenario: Finish button navigates to Checkout: Complete page

    @cart-contents
    #assert that the correct items appears, their name, description, price, quantity, and order.
    Scenario: Cart list displays all added items

    #SauceCard #31337
    Scenario: Payment information section displays correct text

    #Free Pony Express Delivery!
    Scenario: Shipping information section displays correct text	

    #values based on the items you have in your cart. Is tax based on a percentage?
    Scenario: Price Total is calculated correctly

    Scenario: Cannot access Checkout: Overview page via direct URL
