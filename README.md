# Bug-Centre

## New project
dotnet new webapp --auth Individual

## Create model and then run this to scaffold pages 
(`-outDir Pages\Bugs` seems to run as `-outDir PagesBugs`, will need to fix this)  
https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/model?view=aspnetcore-3.1&tabs=visual-studio-code  
`dotnet aspnet-codegenerator razorpage -m Bug -dc BugCentreContext -udl -outDir Pages\Bugs --referenceScriptLibraries`

## Migrations
```cd '.\_src\DB Context Library\'
dotnet ef migrations add InitalDB --startup-project ..\BugCentre\ --context BugCentreContext
dotnet ef database update --startup-project ..\BugCentre\ --context BugCentreContext
```

## TODO
- [x] Move DB and model code into their own DLLs
- [ ] Tie bugs to users and eventually projects. Each user in a project an access all bugs in a project no matter who raised them
- [ ] Upgrade to .NET 5
- [ ] Change layout from default template to custom
- [ ] Allow private bugs to be reported
- [ ] Allow bugs to be assigned and fixed
- [ ] Allow bugs to have comments as they are progressed
- [ ] Give bugs status (Raised, Assigned, Fixed etc.)
- [ ] All unit tests (Should ideally be done from the beginning, but there is enough to lean for now)
- [ ] Add graphs that show bugs raised, closed etc. in a stats section
- [ ] Add image support
- [ ] Add ability to auto wide the DB and start with a few default bug items to keep DB size down if using this as a demo site
- [ ] Add ability to email bug status
- [ ] Think of more items I want this to do
