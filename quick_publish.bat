@echo off
cls

cd /d %~dp0
call Sxh.Server\release.bat
cd /d %~dp0
call Sxh.Client\release.bat