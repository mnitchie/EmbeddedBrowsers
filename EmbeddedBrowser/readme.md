

## To develop
1. Download the .net core 3.1+ sdk from [here](https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.201-macos-x64-installer)
2. After installation, close/re-open a terminal and typer `dotnet` to verify installation was successful
    * If you get the error message `dotnet command not found`, add the following to your `~/.bash_profile`, restart your terminal session, and try again: `test -x /usr/libexec/path_helper && eval $(/usr/libexec/path_helper -s)`
3. `dotnet run`. This will pull down any/all needed dependencies then run the application.

## To build and deploy a new version
1. Execute `./build.sh`. This will create three platform-specific versions of the browser (mac, windows, linux)
2. 
1. To "Release" a new version, upload `TheWorstBrowser.exe` to [the wiki](https://wiki.duosec.org/display/dev/Embedded+Browsers).

## Why isn't this in python?

Because I couldn't find a way to create an embedded browser in python that worked in a cross-platform way that mimicked the behavior we see in the embedded apps we're trying to mimic. If you know of a way, please be my guest :-). It would be great if this tool were written in a language more people at Duo would be familiar with.