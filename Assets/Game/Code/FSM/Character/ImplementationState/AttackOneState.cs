using Assets.Game.Code.Enums.Characters;
using Assets.Game.Code.FSM.Abstract;
using Assets.Game.Code.FSM.Character;
using UnityEngine;

namespace Assets.Game.Code.FSM.Character.ImplementationState
{
    internal sealed class AttackOneState : CharacterBaseState
    {
        public AttackOneState(CharacterFSM characterFSM) : base(characterFSM) { }

        public override void Enter()
        {
            //characterFSM.Animator.Play("AttackOne");
            //attackDuration = characterFSM.Animator.GetCurrentAnimatorStateInfo(0).length - ATTACK_DURATION_OFFSET;
            //timer = 0;
        }

        public override void Update()
        {
            //if (characterFSM.IsAttackingOne == true)
            //{
            //    timer += Time.deltaTime;
            //    if (timer <= attackDuration) return;

            //    characterFSM.IsAttackingOne = false;
            //    characterFSM.ChangeState(CharacterState.IdleOne);
            //}


            if (characterFSM.IsAttackingOne == false)
            {
                characterFSM.ChangeState(CharacterState.IdleOne);
            }
        }

        public override void Exit() { }
    }
}
