# Setup

This document provides steps that required to be executed in order to successfully set up the infrastructure using Docker and Docker Compose.

Setup contains 4 crucial steps:
 - Building Images
 - Running Services 
 - Data Migration
 - Data Ingest

Initial setup requires all 4 steps to be executed. After initial setup, only second step (Running Services) to be performed.
Building Images, Data migration and Data ingest are meant to be run only once.

**Note**: All commands require to be executed in `stacks` directory!

### 1. Building Images

First step is to build images for Smart Tutor and Gateway services. 

```shell
docker-compose --env-file config/env.conf build
```

Default configuration creates `cleancadet/smart-tutor:latest` and `cleancadet/gateway:latest` images.

Also build Smart Tutor migration image that creates required database schema for Smart Tutor service.

```shell
docker-compose --env-file config/env.conf \
  --file docker-compose.migration.yml \
  build
```

Previous command creates `cleancadet/smart-tutor:migration-latest` image.

### 2. Running Services

If default port is changed in config/env.conf file make sure that is also changed inside config/cors/cors.txt file.

When images are built, next step is to run services.

```shell
docker-compose --env-file config/env.conf up --detach
```

**Note**: Make sure that database service is ready to be used by checking 
database logs.

#### Database Logs
Run the following command:
```shell
docker-compose --env-file config/env.conf logs database
```

Last lines of the output should be like this:

```
database_1     | 2021-08-31 11:42:52.832 UTC [1] LOG:  listening on IPv4 address "0.0.0.0", port 5432
database_1     | 2021-08-31 11:42:52.832 UTC [1] LOG:  listening on IPv6 address "::", port 5432
database_1     | 2021-08-31 11:42:52.838 UTC [1] LOG:  listening on Unix socket "/var/run/postgresql/.s.PGSQL.5432"
database_1     | 2021-08-31 11:42:52.846 UTC [85] LOG:  database system was shut down at 2021-08-31 11:42:52 UTC
database_1     | 2021-08-31 11:42:52.852 UTC [1] LOG:  database system is ready to accept connections
```

### 3. Data Migration

Run the migration script for Smart Tutor service:

```shell
docker-compose --env-file config/env.conf \
  --file docker-compose.migration.yml \
  run smart-tutor-migration
```

The services are accessible on http://127.0.0.1:8080 address. By default, database schema for Smart Tutor service is empty. If data for that service needs to be ingested with already prepared data, take a look at Data Ingest section.

### 4. Data Ingest

The next command ingest data into database used by Smart Tutor service:

```shell
docker-compose --env-file config/env.conf \
  exec \
    --user postgres \
    database \
    psql -f /tmp/smart-tutor-init.sql
```

### 5. Destroy Infrastructure

In order to remove the previously created infrastructure, the following command should be executed:

```shell
docker-compose --env-file config/env.conf down -v
```

Previous command completely destroys infrastructure. If data needs to be kept remove the `-v` option.
Keep in mind that if data are not removed there is no need to run migration and data ingestion.
