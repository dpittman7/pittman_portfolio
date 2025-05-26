# 1) Build React
FROM node:16-alpine AS react-build
WORKDIR /src/pittman_react
COPY pittman_react/package*.json ./
RUN npm ci
COPY pittman_react/ .
RUN npm run build

# 2) Restore & publish .NET
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS dotnet-build
WORKDIR /src
COPY pittman_mvc/portfolio.csproj pittman_mvc/
COPY pittman_mvc/ pittman_mvc/
WORKDIR /src/pittman_mvc
RUN dotnet publish -c Release -o /app/publish

# 3) Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=dotnet-build /app/publish ./
COPY --from=react-build /src/pittman_react/build ./wwwroot
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "portfolio.dll"]
