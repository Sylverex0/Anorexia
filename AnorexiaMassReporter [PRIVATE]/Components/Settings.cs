using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veylib.ICLI;
using AnorexiaMassReporter__PRIVATE_.Components;

namespace AnorexiaMassReporter__PRIVATE_.Components
{
    public class Settings
    {
        public static string logo = @"  ▄▄▄·  ▐ ▄       ▄▄▄  ▄▄▄ .▐▄• ▄ ▪   ▄▄▄· 
▐█ ▀█ •█▌▐█▪     ▀▄ █·▀▄.▀· █▌█▌▪██ ▐█ ▀█ 
▄█▀▀█ ▐█▐▐▌ ▄█▀▄ ▐▀▀▄ ▐▀▀▪▄ ·██· ▐█·▄█▀▀█ 
▐█ ▪▐▌██▐█▌▐█▌.▐▌▐█•█▌▐█▄▄▌▪▐█·█▌▐█▌▐█ ▪▐▌
 ▀  ▀ ▀▀ █▪ ▀█▄▀▪.▀  ▀ ▀▀▀ •▀▀ ▀▀▀▀▀ ▀  ▀ ";
        public static CLI.StartupProperties startupProperties = new CLI.StartupProperties()
        {
            Author = new CLI.StartupAuthorProperties()
            {
                Name = "SylverEx || Sylver",
                Url = "https://discord.gg/wHhHsdnGnt"
            },

            Logo = new CLI.StartupLogoProperties()
            {
                Text = logo,
                AutoCenter = true,
                VerticalRainbow = true
            },

            MOTD = new CLI.StartupMOTDProperties()
            {
                Text = "Mass Report Tool"
            },

        };
    }
}
