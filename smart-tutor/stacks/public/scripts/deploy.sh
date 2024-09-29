#! /bin/bash

show_help() {
    echo "********** OPTIONS **********"
    printf "  %s\n" "-s|--stage              stage/environment"
    printf "  %s\n" "-e|--environment-file   path to configuration template file which utilizes environment variables, default: ../env.conf.template"
    printf "  %s\n" "-c|--compose-file       path to docker compose file, default: ../public.yml"
    printf "  %s\n" "-d|--docker-config-hash container image of docker config hash tool, default: cleancadet/docker-config-hash:latest"
}

POSITIONAL=()
while [[ $# -gt 0 ]]
do
key="$1"

case $key in
    -e|--environment-file)
    ENVIRONMENT_TEMPLATE_FILE="$2"
    shift 2
    ;;
    -s|--stage)
    STAGE="$2"
    shift 2
    ;;
    -c|--compose-file)
    COMPOSE_FILE="$2"
    shift 2
    ;;
    -d|--docker-config-hash)
    DOCKER_CONFIG_HASH="$2"
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


export STAGE=${STAGE:-dev}
STACK_NAME="clean_cadet_public_${STAGE}"
COMPOSE_FILE=${COMPOSE_FILE:-../public.yml}
ENVIRONMENT_TEMPLATE_FILE=${ENVIRONMENT_TEMPLATE_FILE:-../env.conf.template}
ENVIRONMENT_FILE=./env.${STAGE}.conf
DOCKER_CONFIG_HASH=${DOCKER_CONFIG_HASH:-cleancadet/docker-config-hash:latest}

echo "********** CONFIGURATION **********"
echo "STAGE                     | ${STAGE}"
echo "ENVIRONMENT TEMPLATE FILE | ${ENVIRONMENT_TEMPLATE_FILE}"
echo "STACK NAME                | ${STACK_NAME}"
echo "COMPOSE FILE              | ${COMPOSE_FILE}"

docker create --name config-hash "${DOCKER_CONFIG_HASH}"
docker cp ../ config-hash:
docker start config-hash
sleep 1
docker cp config-hash:/tmp/"${ENVIRONMENT_FILE}" .
docker rm config-hash
docker compose --env-file "${ENVIRONMENT_FILE}" \
               --file "${COMPOSE_FILE}" config \
               | yq 'del(.name) | (.services[].ports[]?.published |= tonumber)' - | docker stack deploy --prune -c - "${STACK_NAME}"
rm "${ENVIRONMENT_FILE}"
