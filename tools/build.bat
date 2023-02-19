@echo off

set SRC_DIR="%~dp0\..\AyceModding"
set DIST_DIR="%~dp0\..\dist"
set BUILD_DIR="%~dp0\..\AyceModding\bin\Debug\net6.0\"
set TOOLS_DIR="%~dp0\..\tools\"

if not exist %DIST_DIR% mkdir %DIST_DIR%

cd %SRC_DIR% || exit 1
dotnet build || exit 1

xcopy %BUILD_DIR%\com.github.toasterparty.AyceModding.dll %DIST_DIR% /y /q || exit 1

echo.
echo Successfully built 'AYCE Modding'
echo.
