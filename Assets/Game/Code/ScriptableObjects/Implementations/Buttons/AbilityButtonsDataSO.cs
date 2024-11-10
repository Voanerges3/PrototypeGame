

using Assets.Game.Code.Enums.Buttons;
using Assets.Game.Code.ScriptableObjects.Abstract;
using UnityEngine;

namespace Assets.Game.Code.ScriptableObjects.Implementations.Buttons
{
    [CreateAssetMenu(fileName = "AbilityButtonsData", menuName = "UI/AbilityButtonsData")]

    internal sealed class AbilityButtonsDataSO : ButtonsDataBaseSO<AbilityButtonType>
    {
    }
}
