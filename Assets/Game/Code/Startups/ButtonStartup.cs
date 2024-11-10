using Assets.Game.Code.Enums.Buttons;
using Assets.Game.Code.Factories.Characters;
using Assets.Game.Code.Services;
using System;
using UnityEngine.Events;

namespace Assets.Game.Code.Startups
{
    internal sealed class ButtonStartup
    {
        private readonly ButtonsFactory buttonsFactory;
        private readonly ParentService parentService;

        public event EventHandler CreateCharacter;
        public event EventHandler<DamageEventArgs> TakeDamageCharacter;

        //[Inject]
        internal ButtonStartup(ButtonsFactory buttonsFactory, ParentService parentService)
        {
            this.buttonsFactory = buttonsFactory;
            this.parentService = parentService;
            CreateButtons();
        }

        private void CreateButtons()
        {
            UnityAction createCharacterAction = () => CreateCharacter?.Invoke(this,EventArgs.Empty);
            UnityAction takeDamageCharacterAction = () => TakeDamageCharacter?.Invoke(this, new DamageEventArgs(20));

            #region ScrollView_BottomLeft_MainScreen

            buttonsFactory.CreateObjectSpawnerButton(parentService.ScrollView_BottomLeft_MainScreen, ObjectSpawnerButtonType.CreateCharacter, false, createCharacterAction);
            buttonsFactory.CreateMenuButton(parentService.ScrollView_BottomLeft_MainScreen, MenuButtonType.TakeDamageCharacter, false, takeDamageCharacterAction);

            #endregion


            #region UpdateSprities
            buttonsFactory.UpdateSpritesAllButtons();
            #endregion
        }
    }

    public class DamageEventArgs : EventArgs
    {
        public int Damage { get; }

        public DamageEventArgs(int damage)
        {
            Damage = damage;
        }
    }
}
