# Favorite Places App

**Note:** Text such as `{Place}` or `{Title}` represents a placeholder for a dynamic value, such as a specific place name.

1. **Screens and Widgets**
   1. **`Your Places` screen**
      1. **Title Bar**: Displays `Your Places` text.
      2. **Background Color**: Dark purple.
      3. **List Behavior**:
         1. Displays `No places added yet` text, centered vertically and horizontally, when no records are displayed.
         2. Displays the `{Title}` text from each Place.
         3. Supports scrolling if there are many Places.
         4. Tapping a Place navigates to the "Please Detail Screen".
      4. **Button**:
         1. Located in the upper right hand corner.
         2. Displays a `+` icon.
         3. Opens `Add New Place` screen.
   2. **`Add New Place` screen**
      1. **Title Bar**: Displays `Add new Place` text  
      2. **Background Color**: Inherited from the `Your Places` screen.
      3. **Text Input**:
         1. Displays placeholder `Title` text.
         2. Input is required; an empty title should trigger a validation message.
      4. **Button**:
         1. Located right below the `Title` text input, centered horizontally.
         2. Displays `+ Add Place` text.
         3. Clicking the button validates input and adds the Place to the `Your Places` list.
         4. After adding, navigates back to the `Your Places` screen
   3. **`{Place}` screen**
      1. **Title Bar**: Displays `{Title}` text from the selected `Place`.
      2. **Background Color**: Inherited from the `Your Places` screen.
      3. **Text**: Displays the `{Title}` text from the selected `Place` centered vertically and horizontally.
2. **Data Management**
   1. Uses **Riverpod** for state management.
3. **Data Model**
   1. **Place**
      1. **Unique ID** (String).
      2. **Title** (String)
      3. **DateTimeStamp** (for sorting by creation date).
4. **Navigation Flow**
   1. `Your Places` → `Add New Place` (via the `+` button).
   2. `Add New Place` → `Your Places` (after successfullly adding a place).
   3. `Your Places` → `{Place}` (by tapping a Place).
   4. `{Place}` → `Your Places` (via the back button).
5. **Logging**

# ✅ SauceDemo Test Project – Requirements

## 🎯 Purpose

To validate core functionality, state management, and critical user workflows in the SauceDemo sample app through automated testing (functional, non-functional, and visual).

## 📂 Functional Requirements (By Area)

### 🔐 Login

- Users can log in with valid credentials
- Invalid logins show appropriate error messages
- Locked out users cannot log in

### 🛒 Inventory

- Items are listed with name, image, description, and price
- Items can be added/removed from the cart
- Sorting updates product order

### 🍔 Menu

- Menu can be opened/closed from any page
- Links route correctly (All Items, About, Logout, Reset)
- Reset App State clears cart and item state

### 🛍 Cart

- Cart reflects added/removed items
- Cart badge updates in real-time
- Checkout process flows through all steps

### 💸 Checkout

- User can complete a purchase with valid input
- Error handling for missing or invalid form fields
- Final order summary calculates correctly

## 🧪 Non-Functional Requirements

- State should persist correctly across pages
- Error and feedback messages should be accessible
- Critical paths should perform under simulated latency

## 🎨 Visual Checks (Planned)

- Elements render without overlap or distortion
- Icons and labels appear in correct positions
- Responsive layout under viewport changes
