using System;
using UnityEngine;

namespace Assets.Game.Code.Services.GameInput
{
    internal sealed class GameInputService
    {
        public event EventHandler OnAttackOne;
        public event EventHandler OnAttackTwo;
        public event EventHandler OnRun;
        public event EventHandler OnSpecial;
        public event EventHandler OnJump;

        private PlayerInputActions playerInputActions; 

        private GameInputService()
        {
            this.playerInputActions = new PlayerInputActions();
            this.playerInputActions.Player.Enable();

            this.playerInputActions.Player.AttackOne.performed += AttackOne_performed;
            this.playerInputActions.Player.AttackTwo.performed += AttackTwo_performed;
            this.playerInputActions.Player.Run.performed += Run_performed;
            this.playerInputActions.Player.Special.performed += Special_performed;
            this.playerInputActions.Player.Jump.performed += Jump_performed;
        }

        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => OnJump?.Invoke(this, EventArgs.Empty);
        private void Special_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => OnSpecial?.Invoke(this, EventArgs.Empty);
        private void Run_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => OnRun?.Invoke(this, EventArgs.Empty);
        private void AttackTwo_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => OnAttackTwo?.Invoke(this, EventArgs.Empty);
        private void AttackOne_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) => OnAttackOne?.Invoke(this, EventArgs.Empty);

        public Vector2 GetDirectionMove()
        {
            var inputVector = this.playerInputActions.Player.Move.ReadValue<Vector2>();
            return inputVector;
        }
    }
}
