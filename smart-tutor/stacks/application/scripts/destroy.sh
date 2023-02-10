#! /bin/bash

POSITIONAL=()
while [[ $# -gt 0 ]]
do
key="$1"

case $key in
    -s|--stage)
    STAGE="$2"
    shift 2
    ;;
    *)    
    POSITIONAL+=("$1")
    shift
    ;;
esac
done
set -- "${POSITIONAL[@]}"

STAGE=${STAGE:-dev}
STACK_NAME="clean_cadet_application_${STAGE}"

docker stack rm "${STACK_NAME}"
docker secret rm "clean_cadet_smart_tutor_jwt_key_${STAGE}"
docker secret rm "clean_cadet_smart_tutor_cors_${STAGE}"