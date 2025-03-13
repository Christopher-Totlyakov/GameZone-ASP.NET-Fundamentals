# GameZone - ASP.NET Core Fundamentals Project

This project is part of the **ASP.NET Core Fundamentals** course at **SoftUni**. It is an online platform called **GameZone**, where console game enthusiasts can exchange information about different games. Registered users have their own zones with favorite games.

## Table of Contents
1. [Identity Requirements](#identity-requirements)
2. [Database Requirements](#database-requirements)
3. [Page Requirements](#page-requirements)
4. [Functionality](#functionality)
5. [Security](#security)
6. [Code Quality](#code-quality)
7. [Scoring](#scoring)
8. [Installation](#installation)


## Identity Requirements

- Scaffold Identity and use the default **IdentityUser**.
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
  ![image](https://github.com/user-attachments/assets/5590ba4e-2aa9-42c1-9656-25c089d63dea)

- **Login Page (logged-out user)**
  ![image](https://github.com/user-attachments/assets/202cd3da-fc63-4d14-a364-744d23eb78ba)

- **Register Page (logged-out user)**
 ![image](https://github.com/user-attachments/assets/98b9cee6-453f-4380-bfa3-072b60668353)

- **/Game/Add (logged-in user)**
 ![image](https://github.com/user-attachments/assets/ac15977a-1917-4376-8af3-870131d38bb5)

- **/Game/All (logged-in user, publisher of a specific game)**
  ![image](https://github.com/user-attachments/assets/35666fb3-2758-483d-97cf-c6b8fccd0dea)

- **/Game/All (logged-in user, not publisher of any game)**
![image](https://github.com/user-attachments/assets/bd6515b4-2631-4a1e-a4a2-358475bceb5a)

- **/Game/MyZone (logged-in user)**
![image](https://github.com/user-attachments/assets/91cf01e0-fc54-4172-9cc2-b2e4943eb08f)
![image](https://github.com/user-attachments/assets/a61d2035-add2-421a-98ff-6650c8f649c6)


- **/Game/Edit/{id} (logged-in user)**
![image](https://github.com/user-attachments/assets/1509d509-754b-4098-9aea-b8d52aa6d2f8)


- **/Game/AddToMyZone?id={id} (logged-in user)**
  - Adds the selected game to the user's collection of games. If the game is already in their collection, it shouldn't be added. If everything is successful, the user must be redirected to their collection "/Game/MyZone" page.
- **/Game/StrikeOut?id={id} (logged-in user)**
  - Removes the selected game from the user's collection of games. If everything is successful, the user must be redirected to "/Game/MyZone" page.
NOTE: The templates should look EXACTLY as shown above.
 ![image](https://github.com/user-attachments/assets/81705ab7-5989-4735-95c6-a52e4d578eab)

- **Game/Details/{id} (logged-in user, publisher of a game)**
 ![image](https://github.com/user-attachments/assets/c46754d9-fe22-48ba-be1e-51c9ee1b7e92)

- **Game/Details/{id} (logged-in user, not a publisher of a game)**
 ![image](https://github.com/user-attachments/assets/b9f4e2f4-66f1-43f4-966b-4bcae837347e)

- **Game/Delete/{id} (logged-in user, publisher of a game)**
  ![image](https://github.com/user-attachments/assets/4a7e7d52-69f3-4be3-8ce4-5339779adf97)


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
