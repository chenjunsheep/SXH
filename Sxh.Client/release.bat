cd /d %~dp0
msbuild Sxh.Client.sln /t:rebuild /p:Configuration=Release
xcopy E:\backup\Draft\���\˽���\account.xml E:\Projects\git\Sxh\Sxh.Client\Sxh.Client\bin\Release\ /s /y /i
xcopy E:\backup\Draft\���\˽���\proxySxh.xml E:\Projects\git\Sxh\Sxh.Client\Sxh.Client\bin\Release\ /s /y /i
xcopy E:\backup\Draft\���\˽���\proxyTzb.xml E:\Projects\git\Sxh\Sxh.Client\Sxh.Client\bin\Release\ /s /y /i
@pause