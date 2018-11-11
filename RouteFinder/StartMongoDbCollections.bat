@ECHO OFF
REM ************************************************************************************************
REM Summary: Starts the mongo DB Database Instance.
REM Author: Pedro Azevedo
REM ************************************************************************************************

SET MongoDB_Console=C:\Program Files\MongoDB\Server\4.0\bin\mongo.exe

REM ****************************************************
REM Don't change anything below this.
REM ****************************************************

ECHO %TIME%: Starting Mongo DB Database
"%MongoDB_Console%" USE PointsDB
"%MongoDB_Console%" --eval "db.createCollection('Points');"
"%MongoDB_Console%" --eval "db.createCollection('Routes');"
REM Insert Collection for Authorization/Authentication
pause

ECHO %TIME%: Starting Database Seeding :: Remove old Data first
REM Insert Data Here
pause

ECHO Mongo DB Finished
PAUSE