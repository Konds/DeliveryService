@ECHO OFF
REM ************************************************************************************************
REM Summary: Starts the mongo DB Server.
REM Author: Pedro Azevedo
REM ************************************************************************************************

SET MongoDB_DataLocation=C:\Data
SET MongoDB_Root=C:\Program Files\MongoDB\Server\4.0\bin\mongod.exe

REM ****************************************************
REM Don't change anything below this.
REM ****************************************************

ECHO %TIME%: Starting Mongo DB Server
"%MongoDB_Root%" --dbpath "%MongoDB_DataLocation%"
pause

ECHO Mongo DB Server Finished
PAUSE