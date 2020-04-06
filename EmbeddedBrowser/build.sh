dotnet publish -c Release -r osx-x64 --self-contained true
dotnet publish -c Release -r win-x64 --self-contained true
dotnet publish -c Release -r linux-x64 --self-contained true

cd bin/Release/netcoreapp3.1/osx-x64/publish/
tar -czvf ../../../../../EmbeddedBrowser-osx-x64.tar.gz *
cd ../../../../../

cd bin/Release/netcoreapp3.1/win-x64/publish/
tar -czvf ../../../../../EmbeddedBrowser-win-x64.tar.gz *
cd ../../../../../

cd bin/Release/netcoreapp3.1/linux-x64/publish/
tar -czvf ../../../../../EmbeddedBrowser-linux-x64.tar.gz *
cd ../../../../../
