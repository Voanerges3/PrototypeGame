

using Assets.Game.Code.Views.Characters;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Game.Code.Presenters.Characters
{
    internal sealed class CharacterDeathPresenter 
    {
        private readonly CharacterDamagePresenter characterDamagePresenter;

        public event EventHandler OnDeath;

        public CharacterDeathPresenter(CharacterDamagePresenter characterDamagePresenter)
        {
            this.characterDamagePresenter = characterDamagePresenter;

            this.characterDamagePresenter.OnHealthDepleted += DeathCharacter;
        }

        private void DeathCharacter(object sender, EventArgs e) => OnDeath?.Invoke(this, EventArgs.Empty);

    }
}
