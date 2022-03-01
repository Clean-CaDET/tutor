FRONTEND_APP_SRC_URL=$1

apk --update --no-cache add \
  curl=7.79.1-r0 \
  tar=1.34-r0 \
  gettext=0.21-r0 && \
curl -L "${FRONTEND_APP_SRC_URL}" | tar -xz && \
mv "$(find . -maxdepth 1 -type d | tail -n 1)" app && \
cd app && \
npm install
