using System;
using ZeroGravity;
using ZeroGravity.Network;
using ZeroGravity.Objects;

namespace Oxide.Game.Hellion.Extensions
{
    public static class TextChatMessageExtensions
    {
        public static Player GetPlayer(this TextChatMessage chatMessage)
        {
            if (chatMessage == null) throw new ArgumentNullException(nameof(chatMessage));
            return Server.Instance.GetPlayer(chatMessage.GUID);
        }
    }
}