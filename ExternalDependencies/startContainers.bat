@ECHO OFF

ECHO.
ECHO Starting Event Store
START docker start cont-canonnapi-eventstore --interactive

ECHO.
ECHO Starting Redis
START START docker start cont-canonnapi-redis --interactive
