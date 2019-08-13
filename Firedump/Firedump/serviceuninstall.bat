REM RUN AS ADMINISTATOR 
cd %~dp0

@ECHO OFF

CALL firedump.exe stop
ECHO Stopping firedump Service
TIMEOUT /T 3

CALL firedump.exe uninstall
ECHO Uninstalling firedump Service
TIMEOUT /T 2
