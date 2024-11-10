using Assets.Game.Code.Enums.Characters;
using Assets.Game.Code.FSM.Abstract;
using Assets.Game.Code.FSM.Character;

namespace Assets.Game.Code.FSM.Character.ImplementationState
{
    internal sealed class DeadState : CharacterBaseState
    {
        public DeadState(CharacterFSM characterFSM) : base(characterFSM) { }
        public override void Enter()
        {
            characterFSM.Animator.Play("Dead");
        }

        public override void Update()
        {
            if (characterFSM.IdDead == false)
                characterFSM.ChangeState(CharacterState.IdleOne);

        }

        public override void Exit()
        {

        }
    }
}
