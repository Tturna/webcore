# Secrets

Stuff like the DB connection strings are defined with bogus values in `appsettings.json`.
The real values are in user secrets. Since the DB uses Docker secrets defined in secret
files, the system could be written to use those but that doesn't help much. Lets not
overengineer something you can fix manually in a minute.
