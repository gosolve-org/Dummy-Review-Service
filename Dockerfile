FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development

# COPY .sln AND ALL .csproj FILES
COPY *.sln .
COPY **/*.csproj ./
# MOVE ALL .csproj FILES TO THEIR ORIGINAL DIRECTORY
RUN dotnet sln list | grep ".csproj" | while read -r line; do mkdir -p $(dirname $line); mv $(basename $line) $(dirname $line); done;

RUN dotnet restore Review.Api

COPY . .

WORKDIR /app/Review.Api
ENTRYPOINT ["dotnet", "watch", "run"]
