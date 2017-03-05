using System;
using ZeroGravity;
using ZeroGravity.Network;
using ZeroGravity.Objects;

namespace Oxide.Game.Hellion.Extensions
{
    public static class HellionExtensions
    {
        public static Player GetPlayer(this TextChatMessage chatMessage)
        {
            if (chatMessage == null) throw new ArgumentNullException(nameof(chatMessage));
            return Server.Instance.GetPlayer(chatMessage.GUID);
        }

        public static Player GetPlayer(this LogInRequest loginRequest)
        {
            if (loginRequest == null) throw new ArgumentNullException(nameof(loginRequest));
            return Server.Instance.GetPlayer(loginRequest.GUID);
        }

        public static NetworkController.Client GetClient(this LogInRequest loginRequest)
        {
            if (loginRequest == null) throw new ArgumentNullException(nameof(loginRequest));

            long sender = loginRequest.Sender;

            if (Server.Instance.NetworkController.clientList.ContainsKey(sender))
            {
                return Server.Instance.NetworkController.clientList[sender];
            }

            if (Server.Instance.NetworkController.clientList.ContainsKey(loginRequest.GUID))
            {
                return Server.Instance.NetworkController.clientList[loginRequest.GUID];
            }

            return null;
        }
    }
}