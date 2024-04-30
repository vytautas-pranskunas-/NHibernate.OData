@echo off

..\Libraries\NuGet\nuget.exe pack -Properties configuration=release
pause >nul