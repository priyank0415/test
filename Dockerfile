# Build .NET API
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS dotnet-build
WORKDIR /app
COPY ./TechSpeck/ ./TechSpeck/
RUN dotnet publish ./TechSpeck/TechSpeck.API -c Release -o out

# Build Node API
FROM node:18 AS node-build
WORKDIR /node-api
COPY ./node-api/ .
RUN npm install

# Final image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy .NET
COPY --from=dotnet-build /app/out ./TechSpeck/

# Copy Node
COPY --from=node-build /node-api ./node-api/

# Install Node.js in final image
RUN apt-get update && apt-get install -y curl
RUN curl -fsSL https://deb.nodesource.com/setup_18.x | bash -
RUN apt-get install -y nodejs

# Expose ports
# .NET API port
EXPOSE 5226
# Node.js API port
EXPOSE 3000

# Create startup script
RUN echo '#!/bin/bash\n\
cd /node-api\n\
npm start &\n\
cd /app/TechSpeck\n\
dotnet TechSpeck.API.dll\n\
' > /app/start.sh && chmod +x /app/start.sh

# Run both APIs
CMD ["/bin/bash", "/app/start.sh"] 
