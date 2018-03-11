@ECHO OFF

ECHO.
ECHO Starting Event Store
START "Event Store" docker start cont-canonnapi-eventstore --interactive

ECHO.
ECHO Starting Redis
START "Redis" docker start cont-canonnapi-redis --interactive
