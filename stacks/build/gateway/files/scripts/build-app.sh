SMART_TUTOR_API_URL=$1
PROD=$2

cd app || exit
export API_HOST=${SMART_TUTOR_API_URL}
envsubst < environment.ts.template > ./src/environments/environment.ts || exit
if [ "$PROD" == "true" ]; then
  npm run build --prod
else
  npm run build:en --prod
fi
cd dist && \
  mv "$(find . -maxdepth 1 -type d | tail -n 1)" /app