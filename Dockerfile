FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY **/*.csproj .
COPY ./nuget.config .
RUN dotnet restore "Review.Api.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "Review.Api/Review.Api.csproj" -c Debug -o out
RUN rm nuget.config

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
ENV ASPNETCORE_URLS="http://*:80"
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Review.Api.dll"]
