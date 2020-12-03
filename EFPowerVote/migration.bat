set filename=%date:~0,4%%date:~5,2%%date:~8,2%%time:~0,2%%time:~3,2%%time:~6,2%
set "filename=%filename: =0%"
dotnet ef migrations add init%filename%
dotnet ef migrations script -o sqlite.sql
pause