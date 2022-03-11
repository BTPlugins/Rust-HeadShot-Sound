using Rocket.API;
using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Logger = Rocket.Core.Logging.Logger;
using UnityEngine;
using Rocket.Core;
using Steamworks;
using System;

namespace RustHeadshot
{
    public class Main : RocketPlugin
    {
        protected override void Load()
        {
            DamageTool.damagePlayerRequested += DamageTool_damagePlayerRequested;
            Logger.Log("#############################################");
            Logger.Log("###             RustHeadShot              ###");
            Logger.Log("###   Plugin Created By blazethrower320   ###");
            Logger.Log("###            Join my Discord:           ###");
            Logger.Log("###     https://discord.gg/YsaXwBSTSm     ###");
            Logger.Log("#############################################");
        }

        private void DamageTool_damagePlayerRequested(ref DamagePlayerParameters parameters, ref bool shouldAllow)
        {
            UnturnedPlayer user = UnturnedPlayer.FromCSteamID(parameters.killer);
            if (parameters.limb == ELimb.SKULL && user != null)
            {
                EffectManager.sendUIEffect(53991, 539, user.Player.channel.owner.transportConnection, true);
            }
        }
        protected override void Unload()
        {
            DamageTool.damagePlayerRequested -= DamageTool_damagePlayerRequested;
        }
    }
}
