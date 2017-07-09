rem ###############################################################
rem ### PREPARE SOURCE CODE #######################################
rem ###############################################################

set PROJECT_NAME=MHMonstersElements
set SOURCE_FOLDER=%PROJECT_NAME%_source

mkdir .\Release
mkdir .\Release\%PROJECT_NAME%_source

xcopy /Y /E .\%PROJECT_NAME% .\Release\%SOURCE_FOLDER%\%PROJECT_NAME%\
xcopy /Y /E .\Documentation .\Release\%SOURCE_FOLDER%\Documentation\
copy /Y .\%PROJECT_NAME%.sln .\Release\%SOURCE_FOLDER%\%PROJECT_NAME%.sln
copy /Y .\Build.bat .\Release\%SOURCE_FOLDER%\Build.bat

rmdir /S /Q .\Release\%SOURCE_FOLDER%\%PROJECT_NAME%\bin
rmdir /S /Q .\Release\%SOURCE_FOLDER%\%PROJECT_NAME%\obj


rem ###############################################################
rem ### PREPARE BUILD #############################################
rem ###############################################################

@echo off
@echo | call ./Build.bat

mkdir .\Release\%PROJECT_NAME%
xcopy /Y /E .\%PROJECT_NAME%\bin\Release\* .\Release\%PROJECT_NAME%
del /F /Q .\Release\%PROJECT_NAME%\*.vshost.exe*

pause
