Note: No snippets of imporant code will be provided because I am concered about plagiarism<br />
<h2>How to use the API</h2>
<p>
	Note: To use the API in API Management service, please refer to after this section<br /><br />
	In order to use the API of student 34494847 the user needs to click this link: <a href="https://api-34494847.azurewebsites.net/swagger/index.html">API-34494847</a>.
	Once the web page has landed, the user will be greeted with the following banner: <br />
	<br /><img src="img/landingbanner.png" alt="API-34494847 landing banner image"/><br />
	The user needs to login with a username and password to be able to use any of the endpoints. The login credentials are not provided in this README file but are provided in the submission form.
	To login to use the endpoints, the user needs to click on the drop down of the /api/Authenticate/login endpoint: <br />
	<br /><img src="img/dropdown.png" alt="API-34494847 login dropdown image"/><br />
	Then the user needs to click the "Try it out button" on the right, enter a valid username and password then click the "Execute" button: <br />
	<br /><img src="img/login.png" alt="API-34494847 login image"/><br />
	If the information is correct, the user will receive a token that is valid for 1 hour to use to access the endpoints, then copy this token to your clipboard: <br />
	<br /><img src="img/token.png" alt="API-34494847 token image"/><br />
	Now that you have a valid token for 1 hour, you need to unlock the endpoints. To do so, click on any of the grey unlocked locks to the right: <br />
	<br /><img src="img/lock1.png" alt="API-34494847 slots image"/><br />
	After doing so, the following window will pop up: <br />
	<br /><img src="img/auth1.png" alt="API-34494847 slots image"/><br />
	Now use the token you have copied to your clipboard earlier. In the value field type "Bearer" followed with a space and then paste the provided token then click the "Authorize" button: <br />
	<br /><img src="img/auth2.png" alt="API-34494847 slots image"/><br />
	Then a new message prompt will show that the user is Authorized, after seeing this message press the "Close" button: <br />
	<br /><img src="img/auth3.png" alt="API-34494847 slots image"/><br />
	Now the user will also notice how the locks changes on the right as follows: <br />
	<br /><img src="img/lock2.png" alt="API-34494847 slots image"/><br />
	And that's it, the user can now access all of the endpoints in the API of student 34494847<br />
	<h3>API Management service</h3>
	In order to use the API of student 34494847 in API Management service, the student will grant access for the users to the resource group as discussed at Hosting further down in the README<br />
	<br />Once the user is at the API Management service, click the "APIs" option on the left panel:<br />
	<br /><img src="img/apipane.png" alt="API-34494847 api pane image"/><br />
	<br />Now select the "ConnectedOffice-API-34494847" API under the "All APIs" panel and then click "Test" on the right panel:<br />
	<br /><img src="img/selectapi.png" alt="API-34494847 select api image"/><br />
	The user needs to login with a username and password to be able to use any of the endpoints. The login credentials are not provided in this README file but are provided in the submission form.
	To login to use the endpoints, the user needs to click on /api/Authenticate/login - POST endpoint: <br />
	<br /><img src="img/loginapi.png" alt="API-34494847 login api image"/><br />
	<br />Then the user needs to enter a valid username and password in the Request body then click the "Send" button: <br />
	<br /><img src="img/requestbod.png" alt="API-34494847 request api image"/><br />
	<br />If the information is correct, the user will receive a token that is valid for 1 hour to use to access the endpoints in the HTTP response, then copy this token to your clipboard: <br />
	<br /><img src="img/httpresponse.png" alt="API-34494847 response api image"/><br />
	Now that you have a valid token for 1 hour, you need to individually unlock the endpoints you want to use. Select any other endpoint and click the "Add header" button: <br />
	<br /><img src="img/header.png" alt="API-34494847 header api image"/><br />
	<br />Click on the drop down for the "NAME" field and select "Authorization": <br />
	<br /><img src="img/autdrop.png" alt="API-34494847 header api image"/><br />
	<br />Now use the token you have copied to your clipboard earlier. In the value field type "Bearer" followed with a space and then paste the provided token then click the "Send" button: <br />
	<br /><img src="img/headerval.png" alt="API-34494847 header api image"/><br />
	<br />And that's it, the user can now view the HTTP response for the selected endpoint in the API of student 34494847<br />
	<br /><img src="img/final.png" alt="API-34494847 header api image"/>
</p>
<h2>Data Access Layer</h2>
<p>
	The Device, Zone and Category tabels in the provided database from Ms Muller have been scaffolded to generate accurate models of the database structure.
	Then dependancy injection was resolved by adding DBContext to the Startup.cs file. Lastly, the database is hosted on Microsoft Azure which the API is connected to using
	the connection string provided by Microsoft Azure.
</p>
<h2>Business Logic Layer</h2>
<p>
	Each controller in the API contains every CRUD operaton (Create, Read, Update, and Delete). Additionally, all other specifications of methods in the project has also been completed.
	The Categories controller has two additional methods as requested, a method where the user GETs all devices based on a category ID being parsed in and a method where the user GETs the number of 
	zones that are associated to a specific category based on the category ID being parsed in. For the Zones controller, one additional method has also been added as requested, the method
	GETs all devices within a specific zone based on the zone ID being parsed in. Then finally, the last requirement, each controller contains a method that checks if an
	item exists before trying to edit or delete the item. <br />
	<br />CategoriesController: <br />
	<br /><img src="img/categoriesendpoints.png" alt="API-34494847 categories image"/><br />
	DevicesController: <br />
	<br /><img src="img/devicesendpoints.png" alt="API-34494847 devices image"/><br />
	ZonesController: <br />
	<br /><img src="img/zonesendpoints.png" alt="API-34494847 zones image"/><br />
	Also note, for the additional methods I joined the entitites using lambdas because it is easier to manage for longevity incase I would like to change something. In doing so,
	I can also see both joined entites in my response body to see how they are linked, like this: <br />
	<br /><img src="img/join.png" alt="API-34494847 join image"/>
</p>
<h2>Security</h2>
<p>
	For the implemented security the student has made use of JWT (JSON Web Token) authentication. Which basically means that the user needs a token (admin token in the student's API) to access any of the endpoints in the API
	as discussed previously "How to use the API". The student also has made extensive use of the .gitignore file to hide any type of file that contains credentials and sensitive information.
	This includes files such as appsettings.json, azure publish profiles etc: <br />
	<br /><img src="img/.gitignore.png" alt="API-34494847 .gitignore image"/><br />
	Deployment of authorization in each controller (admin users only): <br />
	<br />CategoriesController: <br />
	<br /><img src="img/authcategory.png" alt="API-34494847 auth categories image"/><br />
	DevicesController: <br />
	<br /><img src="img/authdevice.png" alt="API-34494847 auth device image"/><br />
	ZonesController: <br />
	<br /><img src="img/authzone.png" alt="API-34494847 auth zones image"/>
</p>
<h2>Hosting</h2>
<p>
	The API and database is hosted on the student's Microsoft Azure account. So, the student's API can be accessed over the internet anywhere in the world by clicking: 
	<a href="https://api-34494847.azurewebsites.net/swagger/index.html">API-34494847</a>. The student also granted access to the provided emails in the submission form to access the student's resource group.<br />
	<br />Student 34494847's resource group includes the following: <br />
	<ul>
        <li>API Management service</li>
		<li>App Service plan</li>
		<li>App Service</li>
		<li>SQL server</li>
		<li>SQL database</li>
    </ul>
	<img src="img/hosting.png" alt="API-34494847 hosting image"/>
</p>
<h2>API Management</h2>
<p>
	The student has setup API Management in Azure: <br />
	<br /><img src="img/apimanagement.png" alt="API-34494847 api management image"/>
</p>
<h2>Scrum Implementation</h2>
<p>
	The student has succesfully kept his GitHub board updated throughout Project 2 as the board was setup in Project 1.
	Also, the student's Project 2 repository is linked to his GitHub board and a lot of effort was done to link the exact repositories of each Project that was done and what must be done
	to each task (Repository and Linked Assessment fields).<br />
	<br /><img src="img/githubboard.png" alt="API-34494847 github board image"/>
</p>
<h2>Source Control</h2>
<p>
	The student has added Project 2 to his GitHub profile on day 1 and every change that has been decided to commit was comitted.
	The branching strategy that was setup in Project 1 was followed to the T which demonstrated an iterative use of GitHub throughout Project 2
	to succesfully manage version control of the project. The student also did a lot of effort in providing a very well laid out README.md file by explaining everything possible
	to make it easier for the person trying to figure everyting out. Aboslutely no credentials are available in the student's repository anywhere.<br />
	<br />Some of the student's first commits was done over 28 days ago and by now probably over a month ago: <br />
	<br /><img src="img/firstcommits.png" alt="API-34494847 first commit image"/>
</p>
<h2>Reference List</h2>
<p>
	The student provided a reference list with over 30 references on the Project 2 repository and the submission form. Only websites that were relevant and actually useful to produce
	this succesful project was referenced. I have found that the <a href="https://stackoverflow.com/">Stack Overflow</a> site was the most useful and Ms Muller was extremely supportive 
	thoughout the project by providing me guidance where I found myself stuck.
</p>