FRONTEND_APP_SRC_URL=$1
apk --update --no-cache add curl tar gettext;
curl -L "${FRONTEND_APP_SRC_URL}" | tar -xz && mv "$(find . -maxdepth 1 -type d | tail -n 1)" app && cd app && npm install
