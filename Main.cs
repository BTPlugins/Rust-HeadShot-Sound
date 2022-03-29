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
    public class Main : RocketPlugin<RustHeadShotConfiguration>
    {
        public static Main Instance;
        protected override void Load()
        {
            Instance = this;
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
            var user = PlayerTool.getPlayer(parameters.killer);
            Player target = parameters.player;
            if (parameters.limb == ELimb.SKULL && user != null)
            {
                if(Main.Instance.Configuration.Instance.KillerHearSound == true)
                {
                    EffectManager.sendUIEffect(53991, 539, user.channel.owner.transportConnection, true);
                }
                if(Main.Instance.Configuration.Instance.TargetHearSound == true)
                {
                    EffectManager.sendUIEffect(53991, 539, target.channel.owner.transportConnection, true);
                }
            }
            
        }
        protected override void Unload()
        {
            DamageTool.damagePlayerRequested -= DamageTool_damagePlayerRequested;
        }
    }
}
