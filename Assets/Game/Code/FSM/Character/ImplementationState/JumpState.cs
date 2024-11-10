using Assets.Game.Code.Enums.Characters;
using Assets.Game.Code.FSM.Abstract;
using Assets.Game.Code.FSM.Character;
using UnityEngine;

namespace Assets.Game.Code.FSM.Character.ImplementationState
{
    internal sealed class JumpState : CharacterBaseState
    {
        public JumpState(CharacterFSM characterFSM) : base(characterFSM)
        {
        }

        public override void Enter()
        {
            // Play the Jump animation
            characterFSM.Animator.Play("Jump");
            characterFSM.Sprite.color = Color.green;
        }

        public override void Update()
        {
            // Check conditions for transitioning to other states
            //if (characterFSM.IsAttackingOne == true)
            //{
            //    characterFSM.ChangeState(CharacterState.AttackOne);
            //}
            //else if (!characterFSM.IsJumping)
            //{
            //    characterFSM.ChangeState(CharacterState.IdleOne);
            //}
        }

        public override void Exit()
        {

            characterFSM.Sprite.color = Color.white;
        }
    }
}
