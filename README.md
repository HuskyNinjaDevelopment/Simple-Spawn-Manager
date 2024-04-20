# FivePD_SpawnManager
Using the Player's department information this plugin is able to determine where to spawn players who are joining the server.\
Once the players join the script deactivates, handling where or how dead players will respawn is out of scope for this plugin.

# Set Up
1) Place the folder containing the .dll file and the config file in the **fivepd/plugins/** folder.
2) If not already present add the line **'./plugins/\*\*/\*.json',** somewhere around line 20 to the file **fivepd/fxmanifest.lua**.

# Config Setup
"DefaultSpawn" is the department you want new players to join. The plugin will grab the coordinates from that option in the config.\
Use the Short Name for your Departments that is defined in your MDT Department Information when adding a location for the player to spawn at.

# Plugin Load Error
![Error Screenshot](https://user-images.githubusercontent.com/123021459/232183012-5111aa39-35b9-458b-bbf1-8e95d5b5b8de.PNG)

This error will occur when the player loads into the game and the spawn manager plugin attempts to load. If you are getting this you did not edit the fivepd/fxmanifest.lua file. The file must be edited to include searching within folders in the fivepd/plugins folder. To add this functionality add the line **'./plugins/\*\*/\*.json',** somewhere around line 20.
