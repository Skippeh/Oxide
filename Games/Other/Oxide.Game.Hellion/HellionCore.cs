using Oxide.Core;
using Oxide.Core.Plugins;
using Oxide.Game.Hellion.Extensions;
using Oxide.Game.Hellion.Loggers;
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
            Interface.Call("OnStart", server);
        }

        [HookMethod("IOnSaved")]
        private void base_OnSaved()
        {
            Interface.Call("OnSaved");
        }

        [HookMethod("IOnTextChat")]
        private void base_OnTextChat(TextChatMessage chatMessage, bool local)
        {
            var player = chatMessage.GetPlayer();
            Interface.Call("OnTextChat", player, chatMessage, local);
        }

        [HookMethod("IOnSpawnStartingModule")]
        private Ship base_OnSpawnStartingModule()
        {
            return Interface.Call("OnSpawnStartingModule") as Ship;
        }

        [HookMethod("IOnLoginPlayer")]
        private void base_OnLoginPlayer(EventSystem.InternalEventData data)
        {
            
        }
    }
}
