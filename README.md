<a id="readme-top"></a>

[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="https://www.github.com/gabecoatess/americangirllookup">
  </a>

<h3 align="center">American Girl Lookup</h3>

  <p align="center">
    Simple ASP.NET MVC web application that allows users to view and showcase a collection of American Girl Dolls. It was created as a fun and educational project to demonstrate my capabilities, enhance my learning, and add to my portfolio.
    <br />
    <a href="https://www.gabecoatess.com/">Go To Website</a>
    ·
    <a href="https://www.github.com/gabecoatess/americangirllookup/issues/new?labels=bug&template=bug-report---.md">Report Bug</a>
    ·
    <a href="https://www.github.com/gabecoatess/americangirllookup/issues/new?labels=enhancement&template=feature-request---.md">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
	<li><a href="#s3">AWS S3 Integration</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

The American Girl Lookup application is designed to provide a user-friendly interface for browsing, searching, and showcasing American Girl Dolls. This project was suggested by a friend and colleague, and it serves as a platform for me to explore and demonstrate my skills in web development using ASP.NET MVC.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



### Built With

- **C#**: Primary language used for backend logic.
- **ASP.NET MVC**: Web framework used to build the application.
- **Razor/HTML/CSS**: Designing frontend of the application.
- **Bootstrap**: Responsive design and styling.
- **Entity Framework**: Database interactions and ORM.
- **AWS S3**: Storing and managing images.
- **AWS CloudFront**: CDN for retrieving doll images.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Getting Started

1. **Clone the repository**:
	```bash
	git clone https://github.com/gabecoatess/AmericanGirlLookup.git
	```
2. **Navigate to the project directory:
	```bash
	cd AmericanGirlLookup
	```
3. **Build the project**:
	Open the solution file `AmericanGirlLookup.sln` in Visual Studio and build the project
4. **Update the database**:
	Ensure you have a local SQL Server instance running, then update the database using Entity Framework:
	```bash
	Update-Database
	```
	
## AWS S3 Integration
To connect the application to an AWS S3 bucket for storing and managing images, follow these steps:
1. Log in to your AWS account and create an S3 bucket. Note the bucket name and region.
2. Set up AWS credentials from the AWS Security Management Console.
3. Update `appsettings.json` file in the project with your AWS S3 bucket details or using CLI configure:
	```bash
	aws configure
	```
4. Install AWS SDK for .NET is installed in the project. If it isn't, add it via NuGet Package Manager:
	```bash
	Install-Package AWSSDK.S3
	```
5. Update any views or references to the bucket name and object tag.

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- CONTACT -->
## Contact

Gabriel Coates - gabrielrcoates@outlook.com

Project Link: [https://github.com/gabecoatess/AmericanGirlLookup](https://github.com/gabecoatess/AmericanGirlLookup)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[issues-url]: https://github.com/gabecoatess/AmericanGirlLookup/issues
[license-url]: https://github.com/gabecoatess/AmericanGirlLookup/blob/master/LICENSE.txt
