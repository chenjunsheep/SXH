cd /d %~dp0
msbuild Sxh.Client.sln /t:rebuild /p:Configuration=Release
xcopy E:\backup\Draft\理财\私享会\account.xml E:\Projects\git\Sxh\Sxh.Client\Sxh.Client\bin\Release\ /s /y /i
xcopy E:\backup\Draft\理财\私享会\proxy.xml E:\Projects\git\Sxh\Sxh.Client\Sxh.Client\bin\Release\ /s /y /i
@pause