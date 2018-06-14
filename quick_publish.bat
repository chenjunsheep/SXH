@echo off
cls

appcmd stop sites "Sxh.Core"
iisreset /stop

call E:\Projects\git\Sxh\mypublish\setup.bat

iisreset /start
appcmd start sites "Sxh.Core"

@pause