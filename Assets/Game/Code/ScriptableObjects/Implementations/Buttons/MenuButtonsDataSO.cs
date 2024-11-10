

using Assets.Game.Code.Enums.Buttons;
using Assets.Game.Code.ScriptableObjects.Abstract;
using UnityEngine;

namespace Assets.Game.Code.ScriptableObjects.Implementations.Buttons
{
    [CreateAssetMenu(fileName = "MenuButtonsData", menuName = "UI/MenuButtonsData")]
    internal sealed class MenuButtonsDataSO : ButtonsDataBaseSO<MenuButtonType>
    {
    }
}
