#! /bin/bash

show_help() {
    echo "********** OPTIONS **********"
    printf "  %s\n" "-n|--name               image name, default: cleancadet/docker-config-hash"
}

POSITIONAL=()
while [[ $# -gt 0 ]]
do
key="$1"

case $key in
    -n|--name)
    NAME="$2"
    shift 2
    ;;
    -h|--help)
    shift 2
    show_help
    exit 0
    ;;
    *)
    POSITIONAL+=("$1")
    shift
    ;;
esac
done
set -- "${POSITIONAL[@]}"

NAME=${NAME:-cleancadet/docker-config-hash}

docker build -t "${NAME}" \
    --file Dockerfile \
    files