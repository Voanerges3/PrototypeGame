

using UnityEngine;

namespace Assets.Game.Code.Services
{
    internal sealed class ParentService : MonoBehaviour
    {
        [field:SerializeField] public Transform ScrollView_BottomLeft_MainScreen { get; private set; }
    }
}
