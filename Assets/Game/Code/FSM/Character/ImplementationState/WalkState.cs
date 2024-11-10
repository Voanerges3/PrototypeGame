using Assets.Game.Code.Enums.Characters;
using Assets.Game.Code.FSM.Abstract;
using Assets.Game.Code.FSM.Character;
using UnityEngine;

namespace Assets.Game.Code.FSM.Character.ImplementationState
{
    internal sealed class WalkState : CharacterBaseState
    {
        public WalkState(CharacterFSM characterFSM) : base(characterFSM) { }
        public override void Enter()
        {
            characterFSM.Animator.Play("Walk");
        }

        public override void Update()
        {
            if (characterFSM.IsWalk == false)
                characterFSM.ChangeState(CharacterState.IdleOne);

        }

        public override void Exit() { }
    }
}
