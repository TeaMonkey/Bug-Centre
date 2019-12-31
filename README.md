# Bug-Centre

#New project
dotnet new webapp --auth Individual

#Create model and then run this to scaffold pages (`-outDir Pages\Bugs` seems to run as `-outDir PagesBugs`, will need to fix this)
https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/model?view=aspnetcore-3.1&tabs=visual-studio-code
dotnet aspnet-codegenerator razorpage -m Bug -dc BugCentreContext -udl -outDir Pages\Bugs --referenceScriptLibraries

#Migrations
dotnet ef migrations add BugsTable --context BugCentreContext
dotnet ef database update --context BugCentreContext