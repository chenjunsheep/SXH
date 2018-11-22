@echo off
cls

if "%version%" ==""  (set "version=1.1.0.0")
if "%pathDestination%" ==""  (set "pathDestination=E:\backup\Draft\理财\私享会\Release\")

if "%pathSettings%" ==""  (set "pathSettings=E:\backup\Draft\理财\私享会\config\")
if "%pathReleaseClient%" ==""  (set "pathReleaseClient=E:\Projects\git\Sxh\Sxh.Client\Sxh.Client\bin\Release\")
if "%pathReleaseUpgrader%" ==""  (set "pathReleaseUpgrader=E:\Projects\git\Sxh\Sxh.Client\Sxh.Client.Upgrader\bin\Release\")
if "%pathServerFile%" ==""  (set "pathServerFile=E:\Projects\git\Sxh\Sxh.Server\Sxh.Server\bin\Release\Sxh\StaticFiles\")

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

echo =============^> ziping application files...
winrar a -ep1 %version%.zip %pathReleaseClient%*.*
winrar d %version%.zip *.pdb Shared.Util.dll Sxh.Shared.dll
rename %version%.zip %version%.txt

echo =============^> upload zipped file to server...
if not exist %pathServerFile% md %pathServerFile%
xcopy %version%.txt %pathServerFile% /s /y /i
del %version%.txt

echo =============^> configurating local application...
xcopy %pathReleaseClient%*.* %pathDestination% /s /y /i
xcopy %pathReleaseUpgrader%*.* %pathDestination% /s /y /i
xcopy %pathSettings%*.* %pathDestination% /s /y /i

echo =============^> release path: %pathDestination%
@pause