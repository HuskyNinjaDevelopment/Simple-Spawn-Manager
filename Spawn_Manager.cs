using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using FivePD.API;
using System;
using FivePD.API.Utils;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FivePD_SpawnManager
{
    internal class Spawn_Manager: Plugin
    {
        private bool _playerSpawned;

        internal Spawn_Manager() { _playerSpawned = false; }

        [EventHandler("playerSpawned")]
        private async void HandlePlayerSpawn()
        {
            if (!_playerSpawned) //trigger once when the player spawns in
            {
                DoScreenFadeOut(0);

                JObject json = JObject.Parse(LoadResourceFile(GetCurrentResourceName(), "plugins/spawn_manager/config.json"));
                PlayerData playerData = Utilities.GetPlayerData();

                Vector3 newLocation = Vector3.Zero;
                try
                {
                    newLocation = JsonConvert.DeserializeObject<Vector3>(json[playerData.DepartmentShortName].ToString());
                }
                catch
                {
                    newLocation = JsonConvert.DeserializeObject<Vector3>(json[json["DefaultSpawn"].ToString()].ToString());
                }

                if (newLocation != Vector3.Zero) //Only set this if we have an actual location to send the player
                {
                    Game.PlayerPed.Position = newLocation;
                }

                DoScreenFadeIn(1000);
                await Delay(1000);

                _playerSpawned = true;
            }
        }
    }
}
