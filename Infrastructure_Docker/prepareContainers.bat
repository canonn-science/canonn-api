@ECHO OFF

ECHO.
ECHO Preparing EVENTSTORE container
docker pull eventstore/eventstore
docker volume create vol-canonnapi-eventstore
docker create --attach STDIN -a STDOUT -a STDERR --name cont-canonnapi-eventstore --publish 2113:2113 -p 1113:1113 --volume vol-canonnapi-eventstore:/var/lib/eventstore eventstore/eventstore

ECHO.
ECHO Preparing REDIS container
docker pull redis
docker volume create vol-canonnapi-redis
docker create --attach STDIN -a STDOUT -a STDERR --name cont-canonnapi-redis --publish 6379:6379 --volume vol-canonnapi-redis:/data redis
