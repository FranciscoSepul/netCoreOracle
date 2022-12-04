FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:9018
EXPOSE 9018


FROM mjibrandl/dotnetcore-angular:latest AS build
WORKDIR /src
COPY ["KernelArchetype/KernelArchetype.csproj", "KernelArchetype/"]
COPY ["KernelArchetype.Repository/KernelArchetype.Repository.csproj", "KernelArchetype.Repository/"]
COPY ["KernelArchetype.Entities/KernelArchetype.Entities.csproj", "KernelArchetype.Entities/"]
COPY ["KernelArchetype.Constants/KernelArchetype.Constants.csproj", "KernelArchetype.Constants/"]
COPY ["DbMigration/DbMigration.csproj", "DbMigration/"]
COPY ["KernelArchetype.BackgroundProcessing/KernelArchetype.BackgroundProcessing.csproj", "KernelArchetype.BackgroundProcessing/"]
COPY ["KernelArchetype.Services/KernelArchetype.Services.csproj", "KernelArchetype.Services/"]
COPY ["KernelArchetype.Dto/KernelArchetype.Dto.csproj", "KernelArchetype.Dto/"]
RUN dotnet restore "KernelArchetype/KernelArchetype.csproj"
COPY . 
WORKDIR "/src/KernelArchetype"
RUN dotnet build "KernelArchetype/KernelArchetype.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KernelArchetype/KernelArchetype.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KernelArchetype.dll"]