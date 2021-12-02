Changes to the domain model or test data might require a few manual steps before Integration tests can be run:
  a. If the schema for the data model changes, manually delete the database before running the integration tests.
  b. If the test data (data.sql) changes, ensure that any curly brackets are doubled (i.e., instead of "{" we want to have "{{"). Most are found in code snippets.

Eventually we will automate these manual steps.