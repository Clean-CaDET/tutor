#! /bin/bash

echo "********** DESTROYING OPERATIONS STACK **********"
./operations/scripts/destroy.sh

echo "********** DESTROYING PUBLIC STACK **********"
./smart-tutor/stacks/public/scripts/destroy.sh

echo "********** DESTROYING APPLICATION STACK **********"
./smart-tutor/stacks/application/scripts/destroy.sh

echo "********** DESTROYING PERSISTENCE STACK **********"
./smart-tutor/stacks/persistence/scripts/destroy.sh