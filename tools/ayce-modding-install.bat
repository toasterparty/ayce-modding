<# : install.bat
:: Based on https://stackoverflow.com/a/15885133/1683264

@echo off
setlocal

echo.
echo Overcooked! AYCE Mod Installer
echo.
echo Please select your game executable
echo Typically ".../steam/steamapps/common/Overcooked! All You Can Eat/Overcooked All You Can Eat.exe"
echo.

for /f "delims=" %%I in ('powershell -noprofile "iex (${%~f0} | out-string)"') do call :install "%%~I"
goto :EOF

:install
set DIST_DIR="%~dp0\..\dist"
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
