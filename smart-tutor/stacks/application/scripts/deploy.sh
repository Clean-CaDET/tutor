#! /bin/bash

show_help() {
    echo "********** OPTIONS **********"
    printf "  %s\n" "-s|--stage                    stage/environment"
    printf "  %s\n" "-e|--environment-file         path to configuration template file which utilizes environment variables, default: ../env.conf.template"
    printf "  %s\n" "-c|--compose-file             path to docker compose file, default: ../application.yml"
    printf "  %s\n" "-j|--jwt-key                  JWT key for application, required"
    printf "  %s\n" "-r|--cors                     CORS configuration, required"
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
    -j|--jwt-key)
    SMART_TUTOR_JWT_KEY="$2"
    shift 2
    ;;
    -r|--cors)
    SMART_TUTOR_CORS="$2"
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

SMART_TUTOR_JWT_KEY=${SMART_TUTOR_JWT_KEY}
SMART_TUTOR_CORS=${SMART_TUTOR_CORS}
export STAGE=${STAGE:-dev}
STACK_NAME="clean_cadet_application_${STAGE}"
COMPOSE_FILE=${COMPOSE_FILE:-../application.yml}
ENVIRONMENT_TEMPLATE_FILE=${ENVIRONMENT_TEMPLATE_FILE:-../env.conf.template}
ENVIRONMENT_FILE=./env.${STAGE}.conf

if [[ -z ${SMART_TUTOR_JWT_KEY} ]]; then
    echo "JWT key must be set!"
    echo "Use -j|--jwt-key option or set SMART_TUTOR_JWT_KEY variable."
    exit 1
fi

if [[ -z ${SMART_TUTOR_CORS} ]]; then
    echo "CORS must be set!"
    echo "Use -r|--cors option or set SMART_TUTOR_CORS variable."
    exit 1
fi

echo "********** CONFIGURATION **********"
echo "STAGE                     | ${STAGE}"
echo "ENVIRONMENT TEMPLATE FILE | ${ENVIRONMENT_TEMPLATE_FILE}"
echo "STACK NAME                | ${STACK_NAME}"
echo "COMPOSE FILE              | ${COMPOSE_FILE}"

printf "%s" "${SMART_TUTOR_JWT_KEY}" \
    | docker secret create "clean_cadet_smart_tutor_jwt_key_${STAGE}" - > /dev/null || exit
printf "%s" "${SMART_TUTOR_CORS}" \
    | docker secret create "clean_cadet_smart_tutor_cors_${STAGE}" - > /dev/null || exit

docker stack deploy -c "${COMPOSE_FILE}" "${STACK_NAME}"

