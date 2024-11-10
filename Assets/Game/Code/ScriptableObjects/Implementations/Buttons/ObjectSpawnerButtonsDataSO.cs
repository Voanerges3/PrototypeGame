

using Assets.Game.Code.Enums.Buttons;
using Assets.Game.Code.ScriptableObjects.Abstract;
using UnityEngine;

namespace Assets.Game.Code.ScriptableObjects.Implementations.Buttons
{
    [CreateAssetMenu(fileName = "ObjectSpawnerButtonsData", menuName = "UI/ObjectSpawnerButtonsData")]

    internal sealed class ObjectSpawnerButtonsDataSO : ButtonsDataBaseSO<ObjectSpawnerButtonType>
    {
    }
}
