#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Projeto02.Presentation.Mvc/Projeto02.Presentation.Mvc.csproj", "Projeto02.Presentation.Mvc/"]
COPY ["Projeto02.IoC/Projeto02.IoC.csproj", "Projeto02.IoC/"]
COPY ["Projeto02.Application/Projeto02.Application.csproj", "Projeto02.Application/"]
COPY ["Projeto02.Domain/Projeto02.Domain.csproj", "Projeto02.Domain/"]
COPY ["Projeto02.Data.SqlServer/Projeto02.Data.SqlServer.csproj", "Projeto02.Data.SqlServer/"]
RUN dotnet restore "Projeto02.Presentation.Mvc/Projeto02.Presentation.Mvc.csproj"
COPY . .
WORKDIR "/src/Projeto02.Presentation.Mvc"
RUN dotnet build "Projeto02.Presentation.Mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Projeto02.Presentation.Mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Projeto02.Presentation.Mvc.dll"]