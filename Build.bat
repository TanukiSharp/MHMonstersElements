set NETFX_VERSION=4.0.30319
set BUILD="%WINDIR%\Microsoft.NET\Framework\v%NETFX_VERSION%\MSBuild.exe"

set PROJECT_NAME=MHMonstersElements
%BUILD% %PROJECT_NAME%.sln /t:Rebuild /p:Configuration=Release /p:Platform="Any CPU"

del %PROJECT_NAME%\bin\Release\*.pdb
del %PROJECT_NAME%.sln.cache

mkdir %PROJECT_NAME%\bin\Release\images
copy %PROJECT_NAME%\Resources\*.png %PROJECT_NAME%\bin\Release\images\
copy %PROJECT_NAME%\Resources\*.xml %PROJECT_NAME%\bin\Release\

pause
