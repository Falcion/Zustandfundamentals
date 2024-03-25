@echo off

REM Get the .csproj file name
for %%i in (*.csproj) do set "csproj_file=%%~ni"

REM Generate the .sln file
dotnet new sln --name Zustand

REM Add the project to the solution
dotnet sln add "%csproj_file%".csproj
