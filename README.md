# PAK.sexy .NET web app

Welcome! Thar be dragons.

## Getting started

The following steps assume you already have a Git client installed, and it's configured to push your changes to a feature branch on a fork of the repo.

## Visual Studio (Must run at least once, easiest method to get started)

1. [Download Visual Studio](https://visualstudio.microsoft.com/downloads/).
1. Clone the repository into your directory of choice.
1. Open Visual Studio and choose 'Open a project or solution' under the 'Get Started' section. Browse to 'PAK-www.csproj' in your working folder for the repo.
1. Visual Studio may tell you some plugins are missing and ask you to install them, just accept any suggested plugins/dependencies.
1. Click the green play button next to 'IIS express' in the toolbar.
1. Visual Studio will build the project dependencies. It may give you a warning about the self-signed certificate. Simply choose 'accept certificate' when asked.
1. A browser should open to https://localhost:5001/ and the application should be running.

## VS Code

1. This step is optional, but nice if you want a simpler and less resource hungry IDE. I prefer [VS Code](https://code.visualstudio.com/Download), which is free, lightweight, and cross-platform.
1. Visual Studio needs to build some config files for VS Code to be able to run the project. [Follow the steps here to export the config](https://dailydotnettips.com/open-your-current-project-in-visual-studio-code-directly-from-visual-studio-ide/) and open the project in VS Code.
1. You'll need to install the [.NET core SDK](https://dotnet.microsoft.com/download/dotnet/3.1) (3.1 as of this writing).
1. Inside VS Code, add the '.NET Core Tools' extension. (Shift-ctrl-X, search by extension name).
1. Then run the application from inside VS Code (F5 in Windows).