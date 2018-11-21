@echo off
cls
if "%pathSettings%" ==""  (set "pathSettings=E:\backup\Draft\理财\私享会\config\")
if "%pathDestination%" ==""  (set "pathDestination=E:\backup\Draft\理财\私享会\Release\")
if "%pathReleaseClient%" ==""  (set "pathReleaseClient=E:\Projects\git\Sxh\Sxh.Client\Sxh.Client\bin\Release\")
if "%pathReleaseUpgrader%" ==""  (set "pathReleaseUpgrader=E:\Projects\git\Sxh\Sxh.Client\Sxh.Client.Upgrader\bin\Release\")

cd /d %~dp0

echo =============^> clearing history files...
if exist %pathReleaseClient% rd /s /q %pathReleaseClient%
if exist %pathReleaseUpgrader% rd /s /q %pathReleaseUpgrader%
if exist %pathDestination% rd /s /q %pathDestination%

echo =============^> publishing Sxh.Client...
cd Sxh.Client
call release.bat
cd..

echo =============^> publishing Sxh.Client.Upgrader...
cd Sxh.Client.Upgrader
call release.bat
cd..

echo =============^> zip application...(TBD, exclude shared assemblies)
echo =============^> upload zipped file to server...(TBD)

echo =============^> configurating local application...
xcopy %pathReleaseClient%*.* %pathDestination% /s /y /i
xcopy %pathReleaseUpgrader%*.* %pathDestination% /s /y /i
xcopy %pathSettings%*.* %pathDestination% /s /y /i

echo =============^> release path: %pathDestination%
@pause