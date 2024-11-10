using Assets.Game.Code.Enums.Characters;
using Assets.Game.Code.FSM.Abstract;
using Assets.Game.Code.FSM.Character;

namespace Assets.Game.Code.FSM.Character.ImplementationState
{
    internal sealed class IdleOneState : CharacterBaseState
    {
        public IdleOneState(CharacterFSM characterFSM) : base(characterFSM) { }

        public override void Enter()
        {
            characterFSM.Animator.Play("IdleOne");
        }

        public override void Update()
        {
            // Check conditions for transitioning to other states
            if (characterFSM.IsWalk)
                characterFSM.ChangeState(CharacterState.Walk);
            else if (characterFSM.IsJumping)
                characterFSM.ChangeState(CharacterState.Jump);
        }

        public override void Exit()
        {

        }
    }
}
