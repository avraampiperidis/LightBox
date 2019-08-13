REM CALL firedump.exe stop
REM ECHO Stopping firedump Service
sc stop firedumpService
TIMEOUT /T 3

sc start firedumpService
TIMEOUT /T 2