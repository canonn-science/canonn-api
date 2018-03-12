@ECHO OFF

ECHO.
CALL deleteContainers.bat

ECHO.
ECHO Recreate container
CALL prepareContainers.bat
