@ECHO OFF

ECHO.
ECHO Stopping Event Store
docker stop --time 2 cont-canonnapi-eventstore

ECHO.
ECHO Stopping Redis
docker stop cont-canonnapi-redis
