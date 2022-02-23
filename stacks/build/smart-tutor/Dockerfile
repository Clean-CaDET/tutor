# syntax=docker/dockerfile:1

ARG ASPNET_VERSION=6.0
ARG SDK_VERSION=6.0

FROM mcr.microsoft.com/dotnet/aspnet:${ASPNET_VERSION} AS base
WORKDIR /app
 

FROM mcr.microsoft.com/dotnet/sdk:${SDK_VERSION} AS build
ENV PROJECT=Tutor.Web
WORKDIR /src
COPY /src .
RUN dotnet restore "${PROJECT}/${PROJECT}.csproj" && \
    dotnet build "${PROJECT}/${PROJECT}.csproj" -c Release
 

FROM build AS publish
ENV PROJECT=Tutor.Web
RUN dotnet publish "${PROJECT}/${PROJECT}.csproj" -c Release -o /app/publish 


FROM base AS final
ENV ASPNETCORE_URLS=http://*:$PORT
COPY --from=publish /app .
WORKDIR /app/publish
CMD ["dotnet", "Tutor.Web.dll"]


FROM build AS migration-base
RUN PATH="$PATH:/root/.dotnet/tools"; \
    dotnet tool install --global dotnet-ef


# Following stages require to be run in network where database is running
# and currently BuildKit does not support running container during build
# in a custom network: https://github.com/moby/moby/issues/40379.
# Workaround is to build image and run the container from that image
# in desired network.

FROM migration-base AS execute-migration

ENV STARTUP_PROJECT=Tutor.Web
ENV TARGET_PROJECT=Tutor.Infrastructure
ENV MIGRATION=init
ENV DATABASE_HOST=""
ENV DATABASE_PASSWORD=""
ENV DATABASE_USERNAME=""
ENV DATABASE_SCHEMA=""

CMD PATH="$PATH:/root/.dotnet/tools"; \
    dotnet-ef migrations add ${MIGRATION} \
        -s "${STARTUP_PROJECT}/${STARTUP_PROJECT}.csproj"\
        -p "${TARGET_PROJECT}/${TARGET_PROJECT}.csproj" \
        --configuration Release && \ 
    dotnet-ef database update ${MIGRATION} \
        -s "${STARTUP_PROJECT}/${STARTUP_PROJECT}.csproj"\
        -p "${TARGET_PROJECT}/${TARGET_PROJECT}.csproj" \
        --configuration Release


FROM migration-base AS generate-schema
RUN PATH="$PATH:/root/.dotnet/tools"; \
    dotnet-ef dbcontext script \
        -s "${STARTUP_PROJECT}/${STARTUP_PROJECT}.csproj"\
        -p "${TARGET_PROJECT}/${TARGET_PROJECT}.csproj" \
        -o sql/init.sql
