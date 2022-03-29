using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RustHeadshot
{
    public class RustHeadShotConfiguration : IRocketPluginConfiguration
    {
        public bool KillerHearSound { get; set; }
        public bool TargetHearSound { get; set; }
        public void LoadDefaults()
        {
            TargetHearSound = true;
            KillerHearSound = true;
        }
    }
}
