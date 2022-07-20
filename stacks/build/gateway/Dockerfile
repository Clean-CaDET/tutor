# syntax=docker/dockerfile:1

FROM node:16.14.0-alpine3.14 AS base
WORKDIR /src
COPY ./files/scripts/install-dependencies.sh .
ARG FRONTEND_APP_SRC_URL=https://github.com/Clean-CaDET/platform-tutor-ui-web/archive/refs/heads/localDeployment.tar.gz
SHELL ["/bin/ash", "-o", "pipefail", "-c"]
RUN ./install-dependencies.sh ${FRONTEND_APP_SRC_URL}
COPY ./files/front/environment.ts.template ./app
COPY ./files/scripts/build-app.sh .

FROM base AS prodBuild
ARG SMART_TUTOR_API_URL
RUN ./build-app.sh ${SMART_TUTOR_API_URL} "true"

FROM nginx:1.21.6-alpine AS gatewayWithFront
COPY --from=prodBuild /app /usr/share/nginx/html/app
COPY ./files/config/nginx.conf /etc/nginx/nginx.conf
COPY ./files/config/api_gateway.conf /etc/nginx/api_gateway.conf

FROM nginx:1.21.6-alpine AS gateway
COPY ./files/config/nginx.conf /etc/nginx/nginx.conf
COPY ./files/config/api_gateway.conf /etc/nginx/api_gateway.conf

FROM base AS enBuild
ARG SMART_TUTOR_API_URL
RUN ./build-app.sh ${SMART_TUTOR_API_URL}

FROM nginx:1.21.6-alpine AS enGateway
COPY --from=enBuild /app /usr/share/nginx/html/app
COPY ./files/config/nginx.conf /etc/nginx/nginx.conf
COPY ./files/config/api_gateway.conf /etc/nginx/api_gateway.conf
