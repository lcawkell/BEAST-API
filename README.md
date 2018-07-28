# BEAST-API

## What have I learned?

### **Commands**

```shell

# Starts a watch session and updates the site when changes are made to code
dotnet watch run

# Creates a new migration based on the models
dotnet ef migrations add [MigrationName]    

# Updates the database based on the created migrations
dotnet ef database update    

# Remove migrations before they have been saved to the DB
dotnet ef migrations remove  

# Rollback database to a previous migration or to 0 (nothing)
dotnet ef database update 0 (or name of a previous migration) 

# Generate an SQL script
dotnet ef migrations script

# Publish the files to production
dotnet publish -f netcoreapp2.1 -c Release

```