# 1. Use the SDK to build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 2. Copy the project file first (this makes builds faster!)
# Assuming your file is at src/SecureAPIRestWithJwtTokens/SecureAPIRestWithJwtTokens.csproj
COPY ["src/SecureAPIRestWithJwtTokens/SecureAPIRestWithJwtTokens.csproj", "SecureAPIRestWithJwtTokens/"]
RUN dotnet restore "SecureAPIRestWithJwtTokens/SecureAPIRestWithJwtTokens.csproj"

# 3. Copy the rest of the source code and build it
COPY ./src .
RUN dotnet publish "SecureAPIRestWithJwtTokens/SecureAPIRestWithJwtTokens.csproj" -c Release -o /app/publish

# 4. Final stage: run the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "SecureAPIRestWithJwtTokens.dll"]