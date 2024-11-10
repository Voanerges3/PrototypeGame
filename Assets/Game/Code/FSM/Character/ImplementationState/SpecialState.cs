

using Assets.Game.Code.Enums.Characters;
using Assets.Game.Code.FSM.Abstract;

namespace Assets.Game.Code.FSM.Character.ImplementationState
{
    internal sealed class SpecialState : CharacterBaseState
    {
        public SpecialState(CharacterFSM characterFSM) : base(characterFSM) { }

        public override void Enter()
        {
            characterFSM.Animator.Play("Special");
        }

        public override void Update()
        {
            if (characterFSM.IsSpecial == false)
                characterFSM.ChangeState(CharacterState.IdleOne);
        }

        public override void Exit()
        {

        }
    }
}
