# dotnet-clean-architecture
An example of implementing clean architecture with .net c# WebApi

### Migration

At the console package manager, select Domain.EF6 as Default Project.
- Update-Database -v -ConnectionStringName "dev"
- Update-Database -v -ConnectionStringName "dev" -TargetMigration:0
- Add-Migration   -v -ConnectionStringName "dev" MigrationName
