<# : install.bat
:: Based on https://stackoverflow.com/a/15885133/1683264

@echo off
setlocal

set DIST_DIR="%~dp0"
set NO_PAUSE=%~1
set BEPINEX_VER=BepInEx-Unity.IL2CPP-win-x64-6.0.0-be.665+6aabdb5

echo.
echo Overcooked! AYCE Mod Installer
echo.

if not exist %DIST_DIR%\com.github.toasterparty.AyceModding.dll goto fail
if not exist %DIST_DIR%\%BEPINEX_VER% goto fail

goto check_params

:fail

echo Corrupt installation package. If you are a developer, please refer to the README.
echo.

pause
exit 1

:check_params

if "%~2" == "" goto blank
call :install %2
goto :EOF

:blank

echo Please select your game executable...
echo Typically "C:\Program Files\Steam\steamapps\common\Overcooked! All You Can Eat\Overcooked All You Can Eat.exe"
echo.

for /f "delims=" %%I in ('powershell -noprofile "iex (${%~f0} | out-string)"') do call :install "%%~I"
goto :EOF

:install
set GAME_DIR="%~dp1"
set BEPINEX_DIR="%~dp1\BepInEx\"
set PLUGINS_DIR="%~dp1\BepInEx\plugins"

echo Installing 'AYCE Modding' into %PLUGINS_DIR%...
echo.

if not exist %BEPINEX_DIR% mkdir %BEPINEX_DIR%
if not exist %PLUGINS_DIR% mkdir %PLUGINS_DIR%

xcopy %DIST_DIR%\%BEPINEX_VER%  %GAME_DIR% /y /q /s /e

xcopy %DIST_DIR%\*.dll %PLUGINS_DIR% /y /q
xcopy %DIST_DIR%\ayce-modding-uninstall.bat %GAME_DIR% /y /q

echo.
echo Successfully installed 'AYCE Modding'
echo (You may now close this window)
echo.

if "%NO_PAUSE%" == "nopause" goto :EOF

pause

goto :EOF

: end Batch portion / begin PowerShell hybrid chimera #>

Add-Type -AssemblyName System.Windows.Forms
$f = new-object Windows.Forms.OpenFileDialog
$f.InitialDirectory = "C:\Program Files\Steam\steamapps\common\Overcooked All You Can Eat\"
$f.Filter = "Overcooked All You Can Eat (*.exe)|*.exe|All Files (*.*)|*.*"
$f.ShowHelp = $false
$f.Multiselect = $false
[void]$f.ShowDialog()
if ($f.Multiselect) { $f.FileNames } else { $f.FileName }
