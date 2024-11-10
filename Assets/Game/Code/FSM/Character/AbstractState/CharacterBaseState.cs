

using Assets.Game.Code.FSM.Character;
using UnityEngine;

namespace Assets.Game.Code.FSM.Abstract
{
    internal abstract class CharacterBaseState
    {
        protected const float ATTACK_DURATION_OFFSET = 0.2f;

        protected CharacterFSM characterFSM;
        protected float attackDuration;
        protected float timer;

        public CharacterBaseState(CharacterFSM characterFSM) => this.characterFSM = characterFSM;

        public abstract void Enter();
        public abstract void Update();
        public abstract void Exit();
    }
}
