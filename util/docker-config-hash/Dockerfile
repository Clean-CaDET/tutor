FROM ubuntu:20.04
WORKDIR /tmp
RUN apt update -y && \
    DEBIAN_FRONTEND=noninteractive apt install -y \
      build-essential \
      gettext \
      jq \
      libjson-xs-perl && \
    curl -L https://cpanmin.us | perl - --self-upgrade && \
    cpanm YAML::XS
COPY ./docker-config-hash.sh .
RUN chmod +x docker-config-hash.sh
ENTRYPOINT ["./docker-config-hash.sh"]