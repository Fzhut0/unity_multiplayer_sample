using Unity.Netcode;
using UnityEngine;

namespace Unity.BossRoom.Gameplay.GameplayObjects
{
    public class NetworkManaState : NetworkBehaviour
    {
        [HideInInspector]
        public NetworkVariable<int> ManaPoints = new NetworkVariable<int>();
    }
}
