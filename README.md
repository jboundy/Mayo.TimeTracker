# Purpose
---
### Business Requirements

1. Store user identification in application on startup

2. Easy UI that allows a timer to start and stop
	- When user presses stop button, new form pops up 
to to gather more information about work performed.

3. Once information is gathered, the application will save
the data to a sql lite database with the users name, time
and details about the work performed from the last form.
	- The data will also be stored locally as a csv file in case of network
issues. 
	- There should be a retry policy in place if the application isn't able
to connect to the database

4. UI layer to publish data that was not synced with the database
	- Write code to validate the data on the local machine and the data 
in the database are the same. 
	- if the data isn't the same, allow the user to sync the data which 
performs the following
	Save the current data in the database into a seperate data structure
	on the local machine.
	
5. Report UI to combine the data and create charts necessary to show 
the end result of the data
	- use the example from the pivot spreadsheet to combine the data
	from sql lite into the spread sheet. 
	- this task my go 2 different ways. One thru the application 
	and one thru excel to connect excel to sql lite and gather the 
	data from the persisted data.

### Getting Started
To create the database run the following in the cli

- dotnet tool install --global dotnet-ef
- dotnet add package Microsoft.EntityFrameworkCore.Design
- dotnet ef migrations add InitialCreate
- dotnet ef database update

To publish to a external source, you'll have to provide argmunets to the database update section

To make alterations to the database, make changes to the models in the DAL project. 
Then run the following commands in the cli
- dotnet ef migrations add NameForYourMigration
- dotnet ef database update

If you want to revert the migration run the following command
- dotnet ef migrations remove

More information about migrations can be found here
https://learn.microsoft.com/en-us/ef/core/cli/dotnet