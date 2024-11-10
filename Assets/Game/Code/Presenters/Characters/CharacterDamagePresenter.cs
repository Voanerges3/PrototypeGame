using Assets.Game.Code.Models.Character;
using Assets.Game.Code.Startups;
using System;
using UnityEngine;
using Zenject;


namespace Assets.Game.Code.Presenters.Characters
{
    internal sealed class CharacterDamagePresenter : IDisposable
    {
        private readonly CharacterModel characterModel;
        private readonly ButtonStartup buttonStartup;

        public event EventHandler OnHealthDepleted;

        public CharacterDamagePresenter(CharacterModel characterModel, ButtonStartup buttonStartup) 
        {
            this.characterModel = characterModel;
            this.buttonStartup = buttonStartup;

            this.buttonStartup.TakeDamageCharacter += TakeDamage;
            // подписать на событие атаки enemy
        }
        public void Dispose()
        {
            this.buttonStartup.TakeDamageCharacter -= TakeDamage;
        }

        private void TakeDamage(object sender, DamageEventArgs e)
        {
            characterModel.Health -= e.Damage;

            if (characterModel.Health <= 0)
                OnHealthDepleted?.Invoke(this, EventArgs.Empty);
        }

    }
}
