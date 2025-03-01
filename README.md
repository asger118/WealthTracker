# WealthTracker

# Docker DB Setup

```Powershell
# Command to pull the Microsoft 2022 sqlserver linux container image
docker pull mcr.microsoft.com/mssql/server:2022-latest

# Command to run the container
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<password>" -p 1433:1433 --name SqlServer --hostname SqlServer -d mcr.microsoft.com/mssql/server:2022-latest
```
