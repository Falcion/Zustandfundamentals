#!/bin/bash

dotnet build --conifugration Debug
dotnet pack --configuration Debug --output ./nuget/Debug/
