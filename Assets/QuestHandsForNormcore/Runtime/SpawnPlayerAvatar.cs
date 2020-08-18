﻿using UnityEngine;
using Normal.Realtime;

namespace absurdjoy
{
    public class SpawnPlayerAvatar : SpawnPrefabOnConnect
    {
        public Transform localHeadReference;
        public Transform localLeftHandReference;
        public Transform localRightHandReference;
        
        protected override void RealtimeConnected(Realtime realtime)
        {
            var avatar = Realtime.Instantiate(prefab.name, ownedByClient, preventOwnershipTakeover, destroyWhenOwnerOrLastClientLeaves);
            
            // Connect the local control components with the avatar components (and only for our local avatar, not the remote avatars);
            avatar.GetComponent<PlayerAvatar>().LinkWithLocal(localHeadReference, localLeftHandReference, localRightHandReference);
        }
    }
}