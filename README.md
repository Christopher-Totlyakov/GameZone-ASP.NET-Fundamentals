# GameZone - ASP.NET Core Fundamentals Project

This project is part of the **ASP.NET Core Fundamentals** course at **SoftUni**. It is an online platform called **GameZone**, where console game enthusiasts can exchange information about different games. Registered users have their own zones with favorite games.

## Table of Contents
1. [Technological Requirements and Overview](#technological-requirements-and-overview)
2. [Identity Requirements](#identity-requirements)
3. [Database Requirements](#database-requirements)
4. [Page Requirements](#page-requirements)
5. [Functionality](#functionality)
6. [Security](#security)
7. [Code Quality](#code-quality)
8. [Scoring](#scoring)
9. [Installation](#installation)

## Technological Requirements and Overview

- Use the provided skeleton: **GameZone-Skeleton.zip**
- All required packages have already been installed.
- The skeleton contains:
  - Areas/Identity/Pages: Scaffold Identity here.
  - Controllers: Implement controller logic.
  - Data: Contains entities models.
  - Models: Implement models here.
  - Views: Provided views where logic related to user authentication needs to be implemented.
  - `appsettings.json`: Make sure to update your connection string.
  - `Program.cs`: Implement security and password requirements.
  
**Important Note:** Seed the database with pre-defined data for the **Genre** entity. Uncomment the code inside `OnModelCreating` in `GameZoneDbContext`.

## Identity Requirements

- Scaffold Identity and use the default **IdentityUser**.
- Remove unnecessary code from the `Login.cshtml` and `Register.cshtml` files. Keep only the necessary code for login and registration functionality.
- Password requirements:
  - Confirmed account: **false**
  - Require digits: **false**
  - Require non-alphanumeric characters: **false**
  - Require uppercase letters: **false**

## Database Requirements

### Game Entity
- **Id**: Unique integer (Primary Key)
- **Title**: String, min length 2, max length 50 (required)
- **Description**: String, min length 10, max length 500 (required)
- **ImageUrl**: Nullable string
- **PublisherId**: String (required)
- **Publisher**: IdentityUser (required)
- **ReleasedOn**: DateTime (required)
- **GenreId**: Integer (foreign key) (required)
- **Genre**: Genre (required)
- **GamersGames**: Collection of type `GamerGame`

### Genre Entity
- **Id**: Unique integer (Primary Key)
- **Name**: String, min length 3, max length 25 (required)
- **Games**: Collection of type `Game`

### GamerGame Entity
- **GameId**: Integer (Primary Key, foreign key) (required)
- **Game**: Game
- **GamerId**: String (Primary Key, foreign key) (required)
- **Gamer**: IdentityUser

Implement the entities with the correct data types and relations. You may use the new syntax for many-to-many relationships without a mapping table.

## Page Requirements

- **Index Page (logged-out user)**
- **Login Page (logged-out user)**
- **Register Page (logged-out user)**
- **/Game/Add (logged-in user)**
- **/Game/All (logged-in user, publisher of a specific game)**
- **/Game/All (logged-in user, not publisher of any game)**
- **/Game/MyZone (logged-in user)**
- **/Game/Edit/{id} (logged-in user)**
- **/Game/AddToMyZone?id={id} (logged-in user)**
- **/Game/StrikeOut?id={id} (logged-in user)**
- **Game/Details/{id} (logged-in user, publisher of a game)**
- **Game/Details/{id} (logged-in user, not a publisher of a game)**
- **Game/Delete/{id} (logged-in user, publisher of a game)**

## Functionality

### Users
- Guests can register, login, and view the Index page.
- Logged-in users can publish, edit, and view games.
- The app should allow users to add games to their collection ("MyZone").
- Users can edit or delete only games they have published.
- Games are shown on the Home Page (`/Game/All`).
  - Publishers see `[Edit]` and `[Details]` buttons.
  - Non-publishers see `[Add to MyZone]` and `[Details]` buttons.
  
### Game Operations
- Add a game to "MyZone" only if the game isn't already in the collection.
- Edit game functionality.
- Remove a game from the user's collection with the "StrikeOut" button.
- On successful actions (e.g., adding/removing games), redirect users to the appropriate page.

## Security

### Access Requirements
- Guests (not logged in) can access:
  - Index Page
  - Login Page
  - Register Page
- Users (logged in) can access:
  - Game/Add
  - Game/Edit (only for games they published)
  - Game/All
  - MyZone page
  - Logout functionality
- Users (logged in) cannot access pages meant for guests.

## Code Quality

- Ensure clean, well-structured code using SOLID principles.
- Follow best practices in software architecture.

## Scoring

- **Identity Requirements**: 5 points
- **Database Requirements**: 10 points
- **Template Requirements**: 10 points
- **Functionality**: 50 points
- **Security**: 5 points
- **Code Quality**: 10 points
- **Data Validation**: 10 points

## Installation
1.Clone the repository:
```bash
   git clone https://github.com/Christopher-Totlyakov/GameZone-ASP.NET-Fundamentals.git
```

### In Package Manager Console    
2.Install the dependencies: Ensure all required packages are installed by running the following command:
```bash
  dotnet restore
```
3.changes ConnectionStrings on yours in appsettings.json
4.migrate to MS SQL Server
```bash
  Update-Database
