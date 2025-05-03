#!/bin/bash

# Start .NET API
echo "Starting .NET API..."
cd TechSpeck
dotnet run --project TechSpeck.API &
echo ".NET API started in background"

# Start Node.js API
echo "Starting Node.js API..."
cd ../node-api
npm install
npm start
