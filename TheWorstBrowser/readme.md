# The Worst Browser

## Background
We typically develop and test the duo prompt in our browser of choice. However, this is not the many many (most?) of our end users experience the prompt. Often this is through a browser embedded in a thick client app - think the cisco VPN or OWA applications or many others. These embedded browsers often have rendering or behavior issues because they run in IE7 compatability mode. These are tricky debug as it is time consuming to set up a local environment to test them and hitting the prompt in a "real" browser, even older versions of IE, don't present the same problems. Embedded browsers seem to have a different set of issues than their non-embedded counterparts.

Enter TheWorstBrowser. It's a simple thick client that wraps internet explorer using a `WebBrowser` component, and it sucks! While it will wrap whatever windows IE version is installed, it will run it in IE7 compatability mode. It will send a user agent similar to this:

`Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; Win64; x64; Trident/7.0; .NET4.0C; .NET4.0E; Tablet PC 2.0)`

## Running it
Execute `.\TheWorstBrowser.exe` from the command line, or double-click the icon.

## Developing it
1. You need a development environment with the .NET sdk [4.7.2+](https://dotnet.microsoft.com/download/dotnet-framework/net472). Microsoft [offers a ready-made vm](https://developer.microsoft.com/en-us/windows/downloads/virtual-machines/), but I have had no luck getting it installed and running. The windows team probably has laptops laying around you could try. I used AWS workspaces, utilizing a `standard` tier windows 10 build, and it worked pretty well. I manually downloaded and installed
    1. The .net sdk linked above
    2. vscode
    3. The sharp extension for vscode
    4. git

2. Make sure csc is in your path. For me this lives in `C:\Windows\Microsoft.NET\Framework64\v4.0.30319`. Edit your path by opening the start menu and typing `path`, then select `Edit the system environment variables`. Click `Environment Variables`, select `Path` under `System Variables` and add an entry/validate that an entry exists.

3. Make your edits and compile with `csc TheWorstBrowser.cs`. You may need to restart your terminal session if you edited your path after it was already opened.

4. To "Release" a new version, upload `TheWorstBrowser.exe` to [the wiki](https://wiki.duosec.org/display/dev/Embedded+Browsers).

## Note
For the absolute worst experience possible, try removing `<meta http-equiv="X-UA-Compatible" content="IE=11">` from the page serving up the prompt, if present. Try setting `content` to different options. [More] (https://stackoverflow.com/questions/6771258/what-does-meta-http-equiv-x-ua-compatible-content-ie-edge-do)

## References:
https://stackoverflow.com/questions/790542/replacing-net-webbrowser-control-with-a-better-browser-like-chrome
https://stackoverflow.com/questions/1786905/web-browser-component-is-ie7-not-ie8-how-to-change-this
https://docs.microsoft.com/en-us/dotnet/framework/winforms/how-to-create-a-windows-forms-application-from-the-command-line 
https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-add-web-browser-capabilities-to-a-windows-forms-application
https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.webbrowser?view=netframework-4.8