# Shopify_Image_App

- [How to run](#running-the-project)
- [Overview](#overview)
- [Dependancies](#dependancies)
- [Considerations](#considerations)
- [Contributors](#contributors)

---

### Running the project

- I have hosted the app on an Azure's free tier plan, so please keep in mind that it will be a bit slow
  - link: [Shopify_Image_App](https://shopify-image-app.azurewebsites.net/)

- Otherwise please clone this repository to your local machine and run the following commands/steps to run the app:

  - In your command prompt or terminal, navigate to the main project directory (check it contains Shopify_Image_App.sln file)
  - run `dotnet restore` command to get all dependencies
  - run `dotnet build`
  - run `dotnet watch run` to open the app in your browser

---

### Overview

- This app was built as part of the Shopify backend developer intern position challenge to build an image repository with some features to handle adding, deleting, 
searching, and sorting images from multiple users with security measures in place and user authentication.
- The app was built using .NET 5 MVC framework in order to make it easy for the tester to see the results of the backend operations in the view pages.

Currently, the app has the following features:

1. Home page

<img src="https://puu.sh/HCUH9/3974933c01.png" alt="home page" />

- The home page will list all of the images added by all users, sorted by most recent additions first.
- It will allow for the users to search images using the image titles. This search can be partial. The reset button will take the user back to the initial view.
- Under each image is some information like the user who added the image and the date of addition. Clicking on the user's name will take you to a page that shows images 
which were shared by that specific user, also sorted by most recent additions.

--

2. Login/Registration

<img src="https://puu.sh/HCUMW/79392c7473.png" alt="login page" />

- Users can register a new account by providing an email, user name, and password. For the purposes of this challenge showcase the password restrictions are very lax and 
only require that the password is at least 8 characters long.
- Users can login by providing the email and password.

<img src="https://puu.sh/HCUO0/7a1d6880f3.png" alt="login page" />

- Once the user is logged in, they can click on "My Images" link under their name in the navigation menu as shown in the screenshot to be redirected to their own page 
where they can view their images, add new images, or delete their previosuly shared images.

--

3. User's Dashboard Page

<img src="https://puu.sh/HCURQ/3b82dd0e00.png" alt="register page" />

- Once the user clicks on the "My Images" link, they will be redirected to their dashboard where they can see all of their previously shared image and are able to either 
add a new image or delete images previously shared.

---

### Dependancies

| Package                             | Purpose                                        |
| ----------------------------------- | ---------------------------------------------- |
| EntityFrameworkCore                 | Code-first ORM                                 |
| EntityFrameworkCore.Design          | Code-first ORM                                 |
| EntityFrameworkCore.Sqlite          | Code-first ORM for Sqlite spefically           |
| Identity.EntityFrameworkCore        | Handles identity authentication/authorization  |
| Moq                                 | Object mocking for X unit testing              |

---

### Considerations

Please consider the following when testing the application:

- I usually prefer to build APIs with .NET and handle end points with a Javascript framework such as React, which allows for robust error handling and testing. However, 
this app was built with MVC due to time restraint and that it is a demo.
- I am not very well versed in unit testing, I have done some tests in the app but it is still a skill I am currently working on, and I wanted to be upfront about it.
- The app might be a bit slow if you visit the link since it is hosted on a free tier Azure server.
- The app was not built with the intent of making it presentable, the main focus was on the functionality.

---

### Contributors

- [Ayman Al-Dali](https://github.com/ayman-d) :octocat:

---
