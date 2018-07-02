cd /d %~dp0
cd..
cd %pathClient%
msbuild %pathClient%.sln /t:rebuild /p:Configuration=Release