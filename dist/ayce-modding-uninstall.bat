@echo off

if not exist "Overcooked All You Can Eat.exe" echo Error: Uninstall script is not in game folder
if not exist "Overcooked All You Can Eat.exe" pause
if not exist "Overcooked All You Can Eat.exe" exit 1

del /f /q changelog.txt 
del /f /q winhttp.dll
del /f /q doorstop_config.ini
del /f /q .doorstop_version
del /f /q leaderboard_scores.json
del /f /q leaderboard_scores.csv
del /f /q OC2Modding.json
del /f /q output_log.txt
del /f /q /s BepInEx
del /f /q /s curl
del /f /q /s dotnet
rmdir BepInEx /S /Q
rmdir curl /S /Q
del "%~f0"
