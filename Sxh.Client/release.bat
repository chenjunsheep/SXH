cd /d %~dp0
msbuild Sxh.Client.sln /t:rebuild /p:Configuration=Release
xcopy E:\backup\Draft\���\˽���\account.xml E:\Projects\git\Sxh\Sxh.Client\Sxh.Client\bin\Release\ /s /y /i
xcopy E:\backup\Draft\���\˽���\proxy.xml E:\Projects\git\Sxh\Sxh.Client\Sxh.Client\bin\Release\ /s /y /i
@pause