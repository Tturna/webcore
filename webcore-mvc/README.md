Currently (19.1.2026) the deployment is wacky.

1. build app with `dotnet publish -o Release`
2. build container image with `docker compose build`
3. run app with `docker compose up -d`

The Release/ directory is hard coded into the dockerfile that builds the container image.
Steps 1 and 2 could and probably should be automated.

# Secrets

Stuff like the DB connection strings are defined with bogus values in `appsettings.json`.
The real values are in user secrets. Since the DB uses Docker secrets defined in secret
files, the system could be written to use those but that doesn't help much. Lets not
overengineer something you can fix manually in a minute.
