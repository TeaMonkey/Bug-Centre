# Bug-Centre

#New project
dotnet new webapp --auth Individual

#Create model and then run this to scaffold pages (`-outDir Pages\Bugs` seems to run as `-outDir PagesBugs`, will need to fix this)
https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/model?view=aspnetcore-3.1&tabs=visual-studio-code
dotnet aspnet-codegenerator razorpage -m Bug -dc BugCentreContext -udl -outDir Pages\Bugs --referenceScriptLibraries

#Migrations
```cd '.\_src\DB Context Library\'
dotnet ef migrations add InitalDB --startup-project ..\BugCentre\ --context BugCentreContext
dotnet ef database update --startup-project ..\BugCentre\ --context BugCentreContext```