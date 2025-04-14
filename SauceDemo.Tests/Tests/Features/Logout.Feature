Feature: Logout

    Scenario: Logged in user is signed out after a certain amount of time
    Scenario: Signed out user cannot navigate back inside the app
        Epic sadface: You can only access '/cart.html' when you are logged in.
    Scenario: Signed out (automatically or manually) user's cart state remains in tact
    Scenario: There is something weird about the auto signout. The app lets you make changes on the Inventory page, but after a while, it logs you out if you try to access the cart. Seems like if you are logged out, you should be redirected to the login screen. I think the logout feature logs you out even if you are making edits.
        Looks like it might be a ten minute auto logout even if you are not idle
    Scenario: Auto logout takes you to the login screen....I think it should happen immediately instead of on navigation. Should I be able to add and remove things from my cart?
    Scenario: Signing out navigates to the Login screen
    Scenario: After you are automaticlaly signed out, you shouldn't be able to add/remove items in the Cart from the inventory screen or the item detail screen
