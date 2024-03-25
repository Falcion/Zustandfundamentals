#!/bin/bash

# Get the .csproj file name
csproj_file=$(ls -R | grep '\.csproj$')

# Generate the .sln file
dotnet new sln --name Zustand

# Add the project to the solution
dotnet sln add "${csproj_file}"
