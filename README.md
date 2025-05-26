
# React .NET CORE Portfolio
Welcome to the React .NET CORE Portfolio repository! This repository contains the source code for a portfolio website built using the React JavaScript library for the frontend and .NET CORE for the backend.

Frontend
-
The frontend of the portfolio uses the Three-React-Fiber library to create 3D graphics and animations, making the site visually appealing and interactive.

Backend
-
The backend of the portfolio is built using .NET CORE and provides a RESTful API for communication with the frontend. The API is used to retrieve information from the database and perform other backend operations.

InstructGPT Integration
-
The portfolio website also has a InstructGPT integration, which is powered by an API controller. The API controller communicates with OpenAI's language model, InstructGPT, to provide users with information and answers to their questions.

Getting Started
-
Visit https://www.pittman.in to view the website live! 

To run the portfolio locally, you will need to have the following tools installed on your computer:

.NET CORE SDK : ``` https://aka.ms/dotnet-core-applaunch?framework=Microsoft.AspNetCore.App&framework_version=6.0.0&arch=x64&rid=win-x64&os=win10 ```
Node.js (18.0+)
Once you have these tools installed, follow these steps to run the portfolio locally:

Clone this repository to your local machine

```git clone https://github.com/dpittman7/pittman_portfolio.git```

Navigate to the root directory of the repository and install the required dependencies

``` cd pittman_portfolio ```

Then clone the repo for the frontend, you want the location to be within the /pittman_portfolio directory

``` https://github.com/dpittman7/pittman_react.git ```

within the root directories, run npm install

``` npm install ```

Start the .NET CORE API

`dotnet run --project ./pittman_mvc/`

Start the React frontend

`npm start`


The portfolio website should now be running on http://localhost:3000.

Common Error
-
Fetch request fails. Resolution: Need to configure ports within projects proxy handler.
https://stackoverflow.com/questions/48291950/proxy-not-working-for-react-and-node

Future Considerations
-
I welcome feedback to the React .NET CORE Portfolio repository. If you have an idea for a new feature or have found a bug, please contact me via the methods on the website.

- Implement Bezier Camera ZoomIn onClick to DEANTA PITTMAN object. 
    - Further research state management with seperate components using same hook effect.
- Subsitute pdf renderer with one that embeds pdfviewer onto page.

License
-
It's a portfolio, free game. Just @me or star the repo atleast please.
