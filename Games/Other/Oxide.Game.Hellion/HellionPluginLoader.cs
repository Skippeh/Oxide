using System;
using Oxide.Core.Plugins;

namespace Oxide.Game.Hellion
{
    public class HellionPluginLoader : PluginLoader
    {
        public override Type[] CorePlugins => new[] { typeof(HellionCore) };
    }
}