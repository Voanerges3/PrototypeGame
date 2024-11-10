using Assets.Game.Code.Enums.Characters;
using Assets.Game.Code.FSM.Abstract;
using Assets.Game.Code.FSM.Character;
using UnityEngine;

namespace Assets.Game.Code.FSM.Character.ImplementationState
{
    internal sealed class AttackTwoState : CharacterBaseState
    {
        public AttackTwoState(CharacterFSM characterFSM) : base(characterFSM) { }

        public override void Enter()
        {
            characterFSM.Animator.Play("AttackTwo");
        }

        public override void Update()
        {
            if (characterFSM.IsAttackingTwo == false)
                characterFSM.ChangeState(CharacterState.IdleOne);
        }

        public override void Exit()
        {

        }
    }
}
