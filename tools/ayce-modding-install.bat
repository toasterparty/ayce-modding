<# : install.bat
:: Based on https://stackoverflow.com/a/15885133/1683264

@echo off
setlocal

set DIST_DIR="%~dp0"
set NO_PAUSE=%1

echo.
echo Overcooked! AYCE Mod Installer
echo.

if not exist %DIST_DIR%\com.github.toasterparty.AyceModding.dll echo Error: Must run from 'dist' dir, not 'tools' dir
if not exist %DIST_DIR%\com.github.toasterparty.AyceModding.dll echo.
if not exist %DIST_DIR%\com.github.toasterparty.AyceModding.dll exit 1

if "%~2" == "" goto blank
call :install %2
goto :EOF

echo Please select your game executable
echo Typically ".../steam/steamapps/common/Overcooked! All You Can Eat/Overcooked All You Can Eat.exe"
echo.

:blank
for /f "delims=" %%I in ('powershell -noprofile "iex (${%~f0} | out-string)"') do call :install "%%~I"
goto :EOF

:install
set GAME_DIR="%~dp1"
set BEPINEX_DIR="%~dp1\BepInEx\"
set PLUGINS_DIR="%~dp1\BepInEx\plugins"

if not exist %BEPINEX_DIR% echo Error: BepInEx does not appear to be installed correctly, please install BepInEx and try agin
if not exist %BEPINEX_DIR% exit 1

if not exist %PLUGINS_DIR% mkdir %PLUGINS_DIR%

echo Installing AYCE modding into %PLUGINS_DIR%...
echo.

xcopy %DIST_DIR%\*.dll %PLUGINS_DIR% /y /q
xcopy %DIST_DIR%\ayce-modding-uninstall.bat %GAME_DIR% /y /q

echo.
echo Successfully installed 'AYCE Modding'
echo.

if %NO_PAUSE% == nopause goto :EOF
pause
goto :EOF

: end Batch portion / begin PowerShell hybrid chimera #>

Add-Type -AssemblyName System.Windows.Forms
$f = new-object Windows.Forms.OpenFileDialog
$f.InitialDirectory = pwd
$f.Filter = "Overcooked All You Can Eat (*.exe)|*.exe|All Files (*.*)|*.*"
$f.ShowHelp = $true
$f.Multiselect = $true
[void]$f.ShowDialog()
if ($f.Multiselect) { $f.FileNames } else { $f.FileName }
