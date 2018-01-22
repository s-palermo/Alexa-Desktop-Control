# Alexa-Desktop-Control

This project creates a Windows desktop application that allows you to control your PC using Amazon's echo devices.

### Prerequisites


| Prerequisite | Installation Instructions |
| ------ | ------ |
| .NET Framework 4.6.1 | [.NET 4.6.1 Developer Pack][PlDb] |
| WiX Toolset 3.11 | [WiX v3.11 Install][PlGh] |
| Configured Amazon Echo | [Amazon Echo Setup Guide][PlGd] |

Make sure these prerequisites are correctly installed/configured before proceding.

### Building

This project was built using .NET Framework 4.6.1.
Restore the packages using Nuget Package Restore.
The project uses CefSharp which is unable to run on the Any CPU configuration.  
Change the project to a x84 or x64 configuration and build.
Make sure to create a release configuration that builds the WiX installers.

### Installing

A release build should create a AlexaDesktopControlBootstrapInstaller.exe in the AlexaDesktopControlBootstrapInstaller\bin\Release directory.
This installer will check the .Net Framework version and install it if not found.  Once completed it will create a desktop shortcut to the executable.

### Running

The executable opens a window to an Amazon login page where the user is required to enter their credentials.  Once entered, a websocket
connection is automatically made to Amazon's alexa event listeners and the application waits for any updates.  In the taskbar the app icon contains a context menu that allows users to view the Alexa dialog screen, configure the commands, and exit the program.

### Configuration

In the configuration view, a user can map a spoken command to alexa to an executed command on their pc.  The spoken command must match exactly what alexa hears (can view in alexa dialog to check) and the action must be a windows CMD that can be executed through the command prompt (can create scripts/batch to execute more advanced actions).

Examples:

Spoken Command:alexa open google
PC Action:start chrome


~~ more advanced configuration methods to come (ie. alexa ask google to search for tigers, alexa put pc to sleep in 10 minutes)



[PlDb]: <https://www.microsoft.com/en-us/download/details.aspx?id=49978>
[PlGh]: <https://github.com/wixtoolset/wix3/releases/tag/wix3111rtm>
[PlGd]: <https://www.amazon.com/gp/help/customer/display.html?nodeId=202189140>
