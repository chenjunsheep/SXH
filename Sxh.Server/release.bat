cd /d %~dp0
cd Sxh.Server

@echo off
cls

appcmd stop sites "Sxh.Core"
iisreset /stop

if "%pathRelease%" ==""  (set "pathRelease=E:\Projects\git\Sxh\Sxh.Server\Sxh.Server\bin\Release\Sxh")
if exist %pathRelease%\ rd /s /q %pathRelease%
dotnet publish -c Release -o %pathRelease%

iisreset /start
appcmd start sites "Sxh.Core"
@pause