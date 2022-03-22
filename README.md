# FileSystem
Simple file system based on folder structure. 
Contains file structure and foundation of file metadata table. 

# Deployment guide
## Prerequisites
- SQL Server database
- .NET 6 runtime (based on the deployment method)

## Database setup 
### Prepare database schema. 
Either run scripts from the FileSystem.SqlServer/dbo/Tables or use Schema compare tool. 

### Seed data
Application itself doesn't seed any data, which means that we need to seed needed data manually. Run the script "RootFolderSeed.sql" from the FileSystem.SqlServer project. 

## Aplication configuration
### Update connection string
In the FileSystem.GrcpServer/appsettings.json, update the "SQLServer" property with connection string to your database. 

## TODOS
- docker-compose not quite wired up
