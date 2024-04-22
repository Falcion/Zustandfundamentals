#!bin/bash

dotnet build --configuration Release
dotnet pack --configuration Release --output ./nuget/Release/
