using System;
using System.Reflection;
using Oxide.Core;
using Oxide.Core.Extensions;

namespace Oxide.Game.Hellion
{
    public class HellionExtension : Extension
    {
        internal static readonly Version AssemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;

        public HellionExtension(ExtensionManager manager) : base(manager)
        {
        }

        public override string Name => "Hellion";
        public override string Author => "Skipcast";
        public override VersionNumber Version => new VersionNumber(AssemblyVersion.Major, AssemblyVersion.Minor, AssemblyVersion.Build);

        public override string[] WhitelistAssemblies => new[]
        {
            "HELLION_Dedicated", "Oxide.Game.Hellion",
            "mscorlib", "Oxide.Core", "System", "System.Core"
        };

        public override string[] WhitelistNamespaces => new[]
        {
            "ZeroGravity",
            "Steamworks", "System.Collections", "System.Security.Cryptography", "System.Text"
        };

        public override void Load() => Manager.RegisterPluginLoader(new HellionPluginLoader());

        public override void OnModLoad()
        {
            if (Interface.Oxide.EnableConsole())
            {
                Interface.Oxide.ServerConsole.Input += ServerConsoleOnInput;
            }
        }

        private void ServerConsoleOnInput(string input)
        {
            // Todo: Handle input
        }
    }
}