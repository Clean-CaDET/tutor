#! /bin/bash

echo "********** DEPLOYING PERSISTENCE STACK **********"
pushd smart-tutor/stacks/persistence/scripts/ > /dev/null || exit
./deploy.sh
popd > /dev/null || exit

echo "********** DEPLOYING APPLICATION STACK **********"
pushd smart-tutor/stacks/application/scripts/ > /dev/null || exit
./deploy.sh
popd > /dev/null || exit

echo "********** DEPLOYING PUBLIC STACK **********"
pushd smart-tutor/stacks/public/scripts/ > /dev/null || exit
./deploy.sh
popd > /dev/null || exit

echo "********** DEPLOYING OPERATIONS STACK **********"
pushd operations/scripts/ > /dev/null || exit
./deploy.sh
popd > /dev/null || exit
