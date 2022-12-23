#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY ./certs/rootCA.pem /root/.local/share/mkcert/
COPY ./certs/rootCA-key.pem /root/.local/share/mkcert/
RUN apt-get update -y && apt-get upgrade -y
RUN apt-get install libnss3-tools curl -y
RUN curl -L https://github.com/FiloSottile/mkcert/releases/download/v1.3.0/mkcert-v1.3.0-linux-amd64 > /usr/local/bin/mkcert
RUN chmod +x /usr/local/bin/mkcert
RUN mkcert -install
RUN rm -rf /usr/local/bin/mkcert
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Review.Api/Review.Api.csproj", "Review.Api/"]
COPY ["Review.Data/Review.Data.csproj", "Review.Data/"]
COPY ["Review.Business/Review.Business.csproj", "Review.Business/"]
RUN dotnet restore "Review.Api/Review.Api.csproj"
COPY . .
WORKDIR "/src/Review.Api"
RUN dotnet build "Review.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Review.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Review.Api.dll"]
