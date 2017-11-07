# dotnet-clean-architecture
An example to implement clean architecture with .net c#

### Migration

At the console package manager, select Domain.EF6 as Default Project.
- Update-Database -ConnectionStringName "dev"
- Update-Database -ConnectionStringName "dev" -TargetMigration:0
- Add-Migration CreateMyModelName
