When changing the schema run the following commands in order:

add-migration init -Context TutorContext
update-database -Context TutorContext
add-migration init -Context EventContext
update-database -Context EventContext
