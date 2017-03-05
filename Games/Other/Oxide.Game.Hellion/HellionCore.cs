using Oxide.Core;
using Oxide.Core.Logging;
using Oxide.Core.Plugins;
using Oxide.Game.Hellion.Extensions;
using Oxide.Plugins;
using ZeroGravity;
using ZeroGravity.Network;
using ZeroGravity.Objects;

namespace Oxide.Game.Hellion
{
    /// <summary>
    /// The core Hellion plugin
    /// </summary>
    public class HellionCore : CSPlugin
    {
        protected Server Server { get; private set; }

        public HellionCore()
        {
            Author = "Skipcast";
            Interface.Oxide.RootLogger.AddLogger(new HellionLogger());
        }

        [HookMethod("IOnStart")]
        private void base_OnStart(Server server)
        {
            Server = server;
            Dbg.Info("OnStart");
            CallHook("OnStart", server);
        }

        [HookMethod("IOnSaved")]
        private void base_OnSaved()
        {
            Dbg.Info("OnSaved");
            CallHook("OnSaved");
        }

        [HookMethod("IOnTextChat")]
        private void base_OnTextChat(TextChatMessage chatMessage, bool local)
        {
            Dbg.Info($"OnTextChat: {chatMessage.MessageText} ({chatMessage.GetPlayer().Name}) local: {local}");
            CallHook("OnTextChat", chatMessage, local);
        }

        [HookMethod("IOnSpawnStartingModule")]
        private void base_OnSpawnStartingModule(Player player, Ship ship)
        {
            Dbg.Info($"OnSpawnStartingModule for player ${player.Name}");
            CallHook("OnSpawnStartingModule", player, ship);
        }

        [HookMethod("IOnLoginPlayer")]
        private void base_OnLoginPlayer(EventSystem.InternalEventData data)
        {
            
        }
    }
}
