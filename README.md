# CustomRPC
Basically lets you do this

![image](https://i.imgur.com/7RGOxiE.png)

Uses https://github.com/Lachee/discord-rpc-csharp.

# How to use

## Windows (with GUI)

Install the latest release from the releases tab, unzip it and double click "CustomRPC.exe".

To get an application id:
* Go to https://discord.com/developers/applications.
* Create a new application.
* Set the icon and app name to whatever you want in your status.
* Copy the application id and paste it in the "Application Id" field.

Then:
* Set the time to the time you want to display.
* Click "Update".

## Linux and MacOS (command line)

* Clone the repository.
* Follow the steps given above to get an application id.
* Publish the CustomRPCCL project to wherever you feel convenient.
* On a terminal, run the binary with the `set` command with the application id to set the default one.
* Run the binary with the following arguments: [days] \<hours> \<minutes> \<seconds> (arguments wrapped in <> are optional.)
