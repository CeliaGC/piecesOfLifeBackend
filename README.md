<h1>My favorite images</h1>

<h2>Project</h2>

This is a proposal for a simple application to manage images on-line. The platform allows to save images by URL link, group them into categories and modify their registration data.

<h2>Design</h2>

The design is thought for an intuitive user experience, with a suggestive landing page that briefly explains the context of the app and links to the image storage form.
The "Gallery" view, allows to obtain a complete gallery of images or a collection filtered by categories.
From each image we can access an enlarged view and the log editor and also delete the image.

<h3>Desktop Views</h3>
 
![Group%202.png](https://github.com/MyFaveImagesProject/MyFaveImgFront/blob/main/src/assets/images/Group%202.png)

<h3>Responsive Views</h3>

![Group%201.png](https://github.com/MyFaveImagesProject/MyFaveImgFront/blob/main/src/assets/images/Group%201.png)
 

<h2>Development</h2>

Both front-end and back-end development is arranged in several layers that make the data, logic and rendering independent, so that the application is scalable.
The data is stored locally in a database in SQL Server Management Studio, which, through the API created in Microsoft Visual Studio Code ("MFI-back" solution), is communicated and printed in the browser through the "My Favourite Images" app.

<h2>Stack</h2>

Git Version Control system
Git Hub plattform

<h3>Front-end</h3>

<h4>Tools</h4>
Visual Studio code

<h4>Lenguages</h4>
Html
CSS
Javascript

<h4>Libraries</h4>
React Vite
React Bootstrap
Axios
Reactrouter DOM
React testing Library

<h3>Back-end</h3>

<h4>Tools</h4>
Microsoft Visual Studio code
Microsoft SQL Server Management Studio 

<h4>Lenguages</h4>
C#
SQL Languages

<h4>Framework</h4>
AspNET.Core Entity Framework 6

<h2>Install the project</h2>

-Clone projects

https://github.com/MyFaveImagesProject/MyFaveImgFront.git

https://github.com/MyFaveImagesProject/MyFaveImgBack.git

<h3>Back-end</h3>

In Microsoft Visual Studio Code:
Packages should be installed automatically when cloning the repository, but in case of problems, they can be checked in Nugget Package Manager. The ones that should be installed are:
- Coverlet collector 3.2.0
- Microsoft.AspNet.WebApi.Cors 5.2.9 (In API project)
- SwashBucle.AspNetCore 6.5.0 (In API project)
- MicrosoftEntityFramework Core 7.0.0 (In Entities project)
- Microsoft.EntityFrameworkCore.SqlServer 7.0.0 (In Entities project, Data)
- Microsoft.EntityFrameworkCore.Tools 7.0.0 (In Data project)
- Microsoft.Extensions.Configuration 7.0.0.0 (In Data project)
- Microsoft.Extensions.Configuration.Json 7.0.0.0 (In Data project)
- Microsoft.NET.Test.Sdk 17.5.0 (In ProjectTest project)
- MSTest.TestAdapter 3.0.2 (In ProjectTest project)
- MSTest.TestFramework 3.0.2 (In Proyectest project)
 
-Add new connection in Server Explorer

-Open Microsoft SQL Server Management Studio and connect to the server.

In Microsoft Visual Studio Code, to connect to the database, run in Package Nuget Console the commands:

- add-migration Initial -Project Data
- update-database
 
-Run the API solution (it should always be running)

<h3>Front-end</h3>

In Visual Studio Code run the command
- npm i

That should install all the necessary dependencies, but if you have any problems with the installation, these are the commands for each installed dependency
- npm install
- npm create vite@latest
- npm run dev (run in a separate terminal that should not be closed)
- npm install axios
- npm i bootstrap@5.3.0-alpha1
- npm i react-router dom
- npm instll vite
- npm install --save-dev vitest
- npm install --save-dev jsdom 
- npm install --save-dev @testing-library/jest-dom
- npm install --save-dev @testing-library/react


<h2>Developer</h2>

Celia Garcia Castilla https://github.com/CeliaGC/Celia_Garcia

I wish you a happy user experience






