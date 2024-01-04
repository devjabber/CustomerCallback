# Customer Callback Service

This application was developed using .Net Core and Angular, and consists of a simple C# class library based service layer with an EF Core based repository hooked up to a web api on the server side.

In-Memory option to store data within EF Core was used for simplicity.

Boostrap was used to keep the UI looking reasonably clean.

Whilst a TDD approach was not taken there are some unit tests targeting the service and web api.

The Angular code is within the CustomerCallback-UI folder and please run the following npm commands when running the site for the first time to install dependencies and start the site.

```
    npm install
    npm start
```    

Visual Studio 2019 Community Edition was used to develop the server side code.
Visual Studio Code was used to develop the Angular code residing in the *CustomerCallback-UI* folder.

The angular code runs on port 4200 as normal and has been configured to listen to the api on port 5000. 
The web api runs on port 5000 by default so running both solutions will enable the client side and server side code to work together seamlessly.

## Assumptions

* No method of displaying all customer callbacks was specified therefore a simple HTML grid was chosen for this purpose to keep things simple.
* Since only insert and read of data was required, I did not include update and delete. Should this be required please let me know and I'd be happy to add this functionality.
* Since optional fields were not specified, assumption made that all fields are mandatory.
* Basic validation added to ensure that date and time for callback are not set in the past.
