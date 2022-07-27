@echo off

set SRC_DIR="%~dp0\..\AyceModding"
set DIST_DIR="%~dp0\..\dist"
set BUILD_DIR="%~dp0\..\AyceModding\bin\Debug\netstandard2.1\"
set TOOLS_DIR="%~dp0\..\tools\"

if not exist %DIST_DIR% mkdir %DIST_DIR%

cd %SRC_DIR% || exit 1
dotnet build || exit 1

xcopy %BUILD_DIR%\com.github.toasterparty.AyceModding.dll %DIST_DIR% /y /q || exit 1
xcopy %TOOLS_DIR%\ayce-modding-install.bat %DIST_DIR% /y /q || exit 1
xcopy %TOOLS_DIR%\ayce-modding-uninstall.bat %DIST_DIR% /y /q || exit 1

echo.
echo Successfully built 'AYCE Modding'
echo.
