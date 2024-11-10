

using Assets.Game.Code.Enums.Characters;
using Assets.Game.Code.Models.Character;
using Assets.Game.Code.Services.GameInput;
using Assets.Game.Code.Views.Characters;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Game.Code.Presenters.Characters
{
    internal class CharacterMovementPresenter : ITickable, IFixedTickable, IDisposable
    {
        private readonly CharacterView characterView;
        private readonly GameInputService gameInputService;
        private readonly CharacterModel characterModel;
        private readonly CharacterDeathPresenter characterDeathPresenter;
        private readonly Rigidbody2D rigidbody2D;

        private float lastDirection = 1f;
        private Vector3 movementVelocity;

        public CharacterMovementPresenter(CharacterView characterView, GameInputService gameInputService, CharacterModel characterModel, CharacterDeathPresenter characterDeathPresenter)
        {
            this.characterView = characterView;
            this.gameInputService = gameInputService;
            this.characterModel = characterModel;
            this.characterDeathPresenter = characterDeathPresenter;

            this.rigidbody2D = this.characterView.GetComponent<Rigidbody2D>();
            Debug.Log(rigidbody2D is not null);

            this.characterDeathPresenter.OnDeath += OnDeath;
        }
        public void Dispose()
        {
            this.characterDeathPresenter.OnDeath -= OnDeath;
        }

        private void OnDeath(object sender, System.EventArgs e)
        {
            movementVelocity = Vector3.zero;
        }

        public void Tick()
        {
            if (characterModel.CurrentState == CharacterState.Dead) return;

            var inputVector = gameInputService.GetDirectionMove();
            inputVector = inputVector.normalized;

            movementVelocity = new Vector3(inputVector.x, inputVector.y) * characterModel.MoveSpeed;
        }

        public void FixedTick()
        {
            rigidbody2D.velocity = movementVelocity;

            if (movementVelocity.x != 0)
                lastDirection = Mathf.Sign(movementVelocity.x);

            Vector3 currentScale = characterView.transform.localScale;
            currentScale.x = lastDirection * Mathf.Abs(currentScale.x);
            characterView.transform.localScale = currentScale;
        }

    }
}
