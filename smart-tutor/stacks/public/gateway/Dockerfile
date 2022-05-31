# syntax=docker/dockerfile:1

FROM node:16.14.0-alpine3.14 AS frontBuild
WORKDIR /src
COPY ./scripts/install-dependencies.sh .
ARG FRONTEND_APP_SRC_URL=https://github.com/Clean-CaDET/platform-tutor-ui-web/archive/refs/heads/master.tar.gz
SHELL ["/bin/ash", "-o", "pipefail", "-c"]
RUN chmod +x ./install-dependencies.sh && \
    ./install-dependencies.sh ${FRONTEND_APP_SRC_URL}
COPY ./front/environment.ts.template ./app
COPY ./scripts/build-app.sh .
ARG SMART_TUTOR_API_URL
RUN chmod +x ./build-app.sh && \
    ./build-app.sh ${SMART_TUTOR_API_URL}

FROM nginx:1.21.6-alpine AS gatewayWithFront
COPY --from=frontBuild /app /usr/share/nginx/html/app
COPY ./config/nginx.conf /etc/nginx/nginx.conf
COPY ./config/api_gateway.conf /etc/nginx/api_gateway.conf

FROM nginx:1.21.6-alpine AS gateway
COPY ./config/nginx.conf /etc/nginx/nginx.conf
COPY ./config/api_gateway.conf /etc/nginx/api_gateway.conf