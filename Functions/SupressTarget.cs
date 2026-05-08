using System;
using Photon.Voice;
using Photon.Realtime;


public static void SupressTarget(object target)
        {
            RaiseEventOptions raiseOptions = new RaiseEventOptions();

            if (target is ReceiverGroup group)
                raiseOptions.Receivers = group;
            else if (target is int[] actors)
                raiseOptions.TargetActors = actors;
            else if (target is RaiseEventOptions options)
                raiseOptions = options;
            else
                return;

            SendOptions sendOptions = new SendOptions
            {
                Reliability = false,
                Channel = 0
            };


            Dictionary<byte, object> voiceData = new Dictionary<byte, object>
            {
                { 1, 255 },
                { 2, 48000 },
                { 3, 2 },
                { 4, 20000 },
                { 5, 30000 },
                { 10, null },
                { 11, (byte)0 },
                { 12, Codec.AudioOpus }
            };

            object[] eventData =
            {
                (byte)0,
                (byte)1,
                new object[] { voiceData }
            };

            PhotonVoiceNetwork.Instance.Client.OpRaiseEvent(
                202,
                eventData,
                raiseOptions,
                sendOptions
            );
        }
