
# The Embedded Browser

## Background

The Embedded Browser is a cross-platform embedded browser. Depending on the OS it will provide a different rendering experience.

1. Mac OS - A webkit-based browser with user-agent `Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_6) AppleWebKit/605.1.15 (KHTML, like Gecko)`. The UA string provided by the anyconnect VPN currently is: `Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_6) AppleWebKit/605.1.15 (KHTML, like Gecko) AnyConnect/4.8.01090 (mac-intel)`. These are both based on mac's [WKWebview](https://developer.apple.com/documentation/webkit/wkwebview)
2. Windows - An Chromium-based Edge browser
3. Linux - similar webkit-based browser as mac 

This is taken from [here](https://blog.stevensanderson.com/2019/11/18/2019-11-18-webwindow-a-cross-platform-webview-for-dotnet-core/)


## To develop

1. Download the .net core 3.1+ sdk from [here](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.201-macos-x64-installer)
2. After installation, close/re-open a terminal and type `dotnet` to verify installation was successful
    * If you get the error message `dotnet command not found`, add the following to your `~/.bash_profile`, restart your terminal session, and try again: `test -x /usr/libexec/path_helper && eval $(/usr/libexec/path_helper -s)`
    * This should allow you to have the same development experience on windows, mac, and linux.
3. `dotnet run`. This will pull down any/all needed dependencies then run the application.

## To build and deploy a new version

1. Execute `./package.sh`. This will create three platform-specific versions of the browser EmbeddedBrowser directory:
    1. EmbeddedBrowser-linux-x64.tar.gz
    2. EmbeddedBrowser-osx-x64.tar.gz
    3. EmbeddedBrowser-win-x64.zip
2. Obviously the above will only work on mac or linux. If you're developing on windows, please make a `package.ps1` :-)
2. Extract the built version for your current platform and run the executable to smoke test that it works

## To run

1. If you're on windows you must also:
    1. Download/install Edge
    2. Download/install the [Microsoft Visual C++ 2015-2019 Redistributable](https://aka.ms/vs/16/release/vc_redist.x64.exe)
    3. If it's still broken, :shrug:. This seems to work for me on Windows 10, but not Windows 8.1 and below
2. Run the `EmbeddedBrowser` executable
4. If you want to tweak the contents of the home page, you can edit the `index.html` and restart without having to rebuild anything.
