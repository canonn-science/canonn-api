@ECHO OFF

ECHO.
ECHO Deleting Event Store container
docker rm -v cont-canonnapi-eventstore
docker volume rm vol-canonnapi-eventstore

ECHO.
ECHO Deleting Redis container
docker rm -v cont-canonnapi-redis
docker volume rm vol-canonnapi-redis
