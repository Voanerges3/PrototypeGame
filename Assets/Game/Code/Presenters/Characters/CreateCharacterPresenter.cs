

using Assets.Game.Code.Enums.Characters;
using Assets.Game.Code.Factories.Characters;
using Assets.Game.Code.Services.GameInput;
using Assets.Game.Code.Startups;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Game.Code.Presenters.Characters
{
    internal sealed class CreateCharacterPresenter
    {
        private readonly ButtonStartup buttonStartup;
        private readonly CharacterFactory characterFactory;

        public CreateCharacterPresenter(ButtonStartup buttonStartup, CharacterFactory characterFactory)
        {
            this.buttonStartup = buttonStartup;
            this.characterFactory = characterFactory;
            this.buttonStartup.CreateCharacter += CreateCharacter;
        }

        private void CreateCharacter(object sender, EventArgs e)
        {
            Debug.Log("Персонаж создан");
            characterFactory.Create(CharacterType.Yukime, Vector2.zero);
        }
    }
}
