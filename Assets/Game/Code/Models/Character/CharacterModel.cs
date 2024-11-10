

using Assets.Game.Code.Enums.Characters;
using UnityEngine;

namespace Assets.Game.Code.Models.Character
{
    internal sealed class CharacterModel
    {
        public int Health = 100;
        public int MaxHealth = 100;
        public int MoveSpeed = 5;
        public Vector3 MovementVelocity = default;
        public CharacterState CurrentState = CharacterState.IdleOne;
    }
}
