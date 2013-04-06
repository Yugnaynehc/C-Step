If you are using Visual C# 2010 Express Edition, detach the Northwind database from SQL Server by running the following command from the command prompt window:

sqlcmd -S.\SQLExpress -E -idetach.sql

If you have detached the Northwind database from the SQL Server Express instance, in the "Suppliers - Complete\Suppliers" folder rename the file "App.config" as "old App.config", and rename the file "VC# Express App.config" as "App.config".

This change is necessary because the "App.config" file contains a database connection string that assumes that the Northwind database is connected to SQL Server Express. 

The connection string in "VC# Express App.config" references the database as an attached file.