@ECHO OFF

ECHO.
ECHO Deleting Event Store container
docker rm -v cont-canonnapi-eventstore

ECHO.
ECHO Deleting Redis container
docker rm -v cont-canonnapi-redis

ECHO.
ECHO Recreate container
CALL prepareContainers.bat
