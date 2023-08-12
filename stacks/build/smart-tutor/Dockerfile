# syntax=docker/dockerfile:1

ARG ASPNET_VERSION=7.0
ARG SDK_VERSION=7.0

FROM mcr.microsoft.com/dotnet/aspnet:${ASPNET_VERSION} AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/sdk:${SDK_VERSION} as build
ENV PROJECT=Tutor.API
ARG SRC_URL=https://github.com/Clean-CaDET/tutor/archive/refs/heads/master.tar.gz
WORKDIR /src
RUN apt update && apt install curl tar && \
    mkdir ../downloads && cd ../downloads && \
    curl -L ${SRC_URL} | tar -xz && \
    mv $(ls -d */|head -n 1) app && mv app/* /src
WORKDIR /src/src
RUN dotnet restore "${PROJECT}/${PROJECT}.csproj" && \
    dotnet build "${PROJECT}/${PROJECT}.csproj" -c Release
 

FROM build AS publish
ENV PROJECT=Tutor.API
RUN dotnet publish "${PROJECT}/${PROJECT}.csproj" -c Release -o /app/publish


FROM base AS final
ENV ASPNETCORE_URLS=http://*:$PORT
COPY --from=publish /app .
WORKDIR /app/publish
CMD ["dotnet", "Tutor.API.dll"]


FROM build as migration-base
RUN PATH="$PATH:/root/.dotnet/tools"; \
    dotnet tool install --global dotnet-ef


# Following stages require to be run in network where database is running
# and currently BuildKit does not support running container during build
# in a custom network: https://github.com/moby/moby/issues/40379.
# Workaround is to build image and run the container from that image
# in desired network.

FROM migration-base AS execute-migration

ENV STARTUP_PROJECT=Tutor.API
ENV MIGRATION=init
ENV DATABASE_SCHEMA=""
ENV DATABASE_HOST=""
ENV DATABASE_PASSWORD=""
ENV DATABASE_USERNAME=""

ENV STAKEHOLDERS_TARGET_PROJECT=Tutor.Stakeholders.Infrastructure

ENV LEARNING_UTILS_TARGET_PROJECT=Tutor.LearningUtils.Infrastructure

ENV KNOWLEDGE_COMPONENTS_TARGET_PROJECT=Tutor.KnowledgeComponents.Infrastructure

ENV COURSES_TARGET_PROJECT=Tutor.Courses.Infrastructure

CMD PATH="$PATH:/root/.dotnet/tools"; \
    dotnet-ef migrations add "${MIGRATION}-stakeholders" \
        -s "${STARTUP_PROJECT}/${STARTUP_PROJECT}.csproj"\
        -p "Modules/Stakeholders/${STAKEHOLDERS_TARGET_PROJECT}/${STAKEHOLDERS_TARGET_PROJECT}.csproj" \
        -c "StakeholdersContext" \
        --configuration Release && \
    dotnet-ef database update "${MIGRATION}-stakeholders" \
        -s "${STARTUP_PROJECT}/${STARTUP_PROJECT}.csproj"\
        -p "Modules/Stakeholders/${STAKEHOLDERS_TARGET_PROJECT}/${STAKEHOLDERS_TARGET_PROJECT}.csproj" \
        -c "StakeholdersContext" \
        --configuration Release && \
    dotnet-ef migrations add "${MIGRATION}-learningUtils" \
        -s "${STARTUP_PROJECT}/${STARTUP_PROJECT}.csproj"\
        -p "Modules/LearningUtilities/${LEARNING_UTILS_TARGET_PROJECT}/${LEARNING_UTILS_TARGET_PROJECT}.csproj" \
        -c "LearningUtilsContext" \
        --configuration Release && \
    dotnet-ef database update "${MIGRATION}-learningUtils" \
        -s "${STARTUP_PROJECT}/${STARTUP_PROJECT}.csproj"\
        -p "Modules/LearningUtilities/${LEARNING_UTILS_TARGET_PROJECT}/${LEARNING_UTILS_TARGET_PROJECT}.csproj" \
        -c "LearningUtilsContext" \
        --configuration Release && \
    dotnet-ef migrations add "${MIGRATION}-knowledgeComponents" \
        -s "${STARTUP_PROJECT}/${STARTUP_PROJECT}.csproj"\
        -p "Modules/KnowledgeComponents/${KNOWLEDGE_COMPONENTS_TARGET_PROJECT}/${KNOWLEDGE_COMPONENTS_TARGET_PROJECT}.csproj" \
        -c "KnowledgeComponentsContext" \
        --configuration Release && \
    dotnet-ef database update "${MIGRATION}-knowledgeComponents" \
        -s "${STARTUP_PROJECT}/${STARTUP_PROJECT}.csproj"\
        -p "Modules/KnowledgeComponents/${KNOWLEDGE_COMPONENTS_TARGET_PROJECT}/${KNOWLEDGE_COMPONENTS_TARGET_PROJECT}.csproj" \
        -c "KnowledgeComponentsContext" \
        --configuration Release && \
    dotnet-ef migrations add "${MIGRATION}-courses" \
        -s "${STARTUP_PROJECT}/${STARTUP_PROJECT}.csproj"\
        -p "Modules/Courses/${COURSES_TARGET_PROJECT}/${COURSES_TARGET_PROJECT}.csproj" \
        -c "CoursesContext" \
        --configuration Release && \
    dotnet-ef database update "${MIGRATION}-courses" \
        -s "${STARTUP_PROJECT}/${STARTUP_PROJECT}.csproj"\
        -p "Modules/Courses/${COURSES_TARGET_PROJECT}/${COURSES_TARGET_PROJECT}.csproj" \
        -c "CoursesContext" \
        --configuration Release && \
