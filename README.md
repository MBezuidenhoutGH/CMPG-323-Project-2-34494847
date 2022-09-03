<h2>How to use the API</h2>
<p>
	In order to use the API of student 34494847 the user needs to click this link: <a href="https://api-34494847.azurewebsites.net/swagger/index.html">API-34494847</a>.
	Once the web page has landed, the user will be greeted with the following banner: <br />
	<br /><img src="img/landingbanner.png" alt="API-34494847 landing banner image"/><br />
	The user needs to login with a username and password to be able to use any of the endpoints. The login credentials are not provided in this README file but are provided in the submission form.
	To login to use the endpoints, the user needs to click on the drop down of the /api/Authenticate/login endpoint: <br />
	<br /><img src="img/dropdown.png" alt="API-34494847 login dropdown image"/><br />
	Then the user needs to click the "Try it out button" on the right, enter a valid username and password then click the "Execute" button: <br />
	<br /><img src="img/login.png" alt="API-34494847 login image"/><br />
	If the information is correct, the user will receive a JWT token that is valid for 1 hour to use to access the endpoints then copy this token to your clipboard: <br />
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
	And that's it, the user can now access all of the endpoints in the API of student 34494847
</p>

<h2>Endpoints in the API</h2>
<p>
	Each controller in the API contains every CRUD operaton (Create, Read, Update, and Delete). Additionally, all other specifications of methods in the project has also been completed.
	The Categories controller has two additional methods as requested, a method where the user GETs all devices based on a category ID being parsed in and a method where the user GETs the number of 
	zones that are associated to a specific category based on the category ID being parsed in. For the Zones controller, one additional method has also been added as requested, the method
	GETs all devices within a specific zone based on the zone ID being parsed in. Then finally, the last requirement, each controller contains a method that checks if an
	item exists before trying to edit or delete the item

	Categories Controller: <br />
	<br /><img src="img/categoriesendpoints.png" alt="API-34494847 categories image"/><br />
	Devices Controller: <br />
	<br /><img src="img/devicesendpoints.png" alt="API-34494847 devices image"/><br />
	Zones Controller: <br />
	<br /><img src="img/zonesendpoints.png" alt="API-34494847 zones image"/><br />
</p>