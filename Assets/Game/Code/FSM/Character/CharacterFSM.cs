

using Assets.Game.Code.Enums.Characters;
using Assets.Game.Code.FSM.Abstract;
using Assets.Game.Code.FSM.Character.ImplementationState;
using Assets.Game.Code.Models.Character;
using Assets.Game.Code.Presenters.Characters;
using Assets.Game.Code.Services.GameInput;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Game.Code.FSM.Character
{
    internal sealed class CharacterFSM : MonoBehaviour
    {
        #region Fields
        public Animator Animator { get; private set; }
        public SpriteRenderer Sprite { get; private set; }
        public CharacterModel CharacterModel { get; private set; }
        
        public bool IsWalk { get; set; }
        public bool IsJumping { get; set; }
        public bool IsAttackingOne { get; set; }
        public bool IsAttackingTwo { get; set; }
        public bool IdDead { get; set; }
        public bool IsSpecial { get; private set; }

        private GameInputService gameInputService;
        private CharacterDeathPresenter characterDeathPresenter;

        private Dictionary<CharacterState, CharacterBaseState> stateDictionary;
        #endregion

        #region Initialization

        [Inject]
        private void Construct(GameInputService gameInputService, CharacterDeathPresenter characterDeathPresenter, CharacterModel characterModel)
        {
            
            this.CharacterModel = characterModel;
            this.gameInputService = gameInputService;
            this.characterDeathPresenter = characterDeathPresenter;
        }

        private void Awake()
        {
            Animator = GetComponent<Animator>();
            Sprite = GetComponent<SpriteRenderer>();

            stateDictionary = new Dictionary<CharacterState, CharacterBaseState>
            {
                { CharacterState.IdleOne, new IdleOneState(this) },
                { CharacterState.Walk, new WalkState(this) },
                { CharacterState.Jump, new JumpState(this) },
                { CharacterState.AttackOne, new AttackOneState(this) },
                { CharacterState.AttackTwo, new AttackTwoState(this) },
                { CharacterState.Dead, new DeadState(this) },
                { CharacterState.Special, new SpecialState(this) }
            };
        }

        private void Start()
        {
            gameInputService.OnAttackOne += OnAttackOne;
            gameInputService.OnAttackTwo += OnAttackTwo;
            gameInputService.OnSpecial += OnSpecial;

            characterDeathPresenter.OnDeath += OnDeath;

            ChangeState(CharacterState.IdleOne);
        }

        #endregion

        #region ChangeState
        public void ChangeState(CharacterState newState)
        {
            ResetState();

            if (stateDictionary.ContainsKey(CharacterModel.CurrentState))
                stateDictionary[CharacterModel.CurrentState].Exit();

            CharacterModel.CurrentState = newState;

            if (stateDictionary.ContainsKey(newState))
                stateDictionary[newState].Enter();
        }
        

        public void ResetState()
        {
            //IsWalk = false;
            IsJumping = false;
            IsAttackingOne = false;
            IsAttackingTwo = false;
            IdDead = false;
            IsSpecial = false;
        }

        [ContextMenu("ResetState")]
        private void ResetContextMenu() => ResetState();

        //private void SetState(CharacterState state)
        //{
        //    ResetState();
        //    ChangeState(state);
        //}
        #endregion

        #region Update
        private void Update()
        {
            if (IdDead == true) return;

            UpdateCurrentState();
            CheckMoveCharocter();
        }
        private void UpdateCurrentState()
        {
            if (stateDictionary.ContainsKey(CharacterModel.CurrentState))
                stateDictionary[CharacterModel.CurrentState].Update();
        }

        private void CheckMoveCharocter()
        {
            var direction = gameInputService.GetDirectionMove();

            if (direction.x != 0 || direction.y != 0)
            {
                ResetState(); // Если будет реализация анимации атаки на ходу, то данный метод необходимо убрать.
                IsWalk = true;
            }
            else
                IsWalk = false;
        }
        #endregion

        #region Actions
        private void OnAttackOne(object sender, EventArgs e)
        {
            if (IdDead == true) return;
            ChangeState(CharacterState.AttackOne);
            IsAttackingOne = true;
        }
        private void OnAttackTwo(object sender, EventArgs e)
        {
            if (IdDead == true) return;
            ChangeState(CharacterState.AttackTwo);
            IsAttackingTwo = true;
        }

        private void OnDeath(object sender, EventArgs e)
        {
            if (IdDead == true) return;
            ChangeState(CharacterState.Dead);
            IdDead = true;
        }

        private void OnSpecial(object sender, EventArgs e)
        {
            if (IdDead == true) return;
            ChangeState(CharacterState.Special);
            IsSpecial = true;
        }
        #endregion
    }
}
