using Assets.Game.Code.Abstracts.Buttons.Abstract;
using Assets.Game.Code.Enums.Buttons;
using Assets.Game.Code.ScriptableObjects.Abstract;
using Assets.Game.Code.ScriptableObjects.Implementations.Buttons;
using Assets.Game.Code.Views.Buttons.Implementations;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Game.Code.Factories.Characters
{
    internal sealed class ButtonsFactory
    {
        #region Fields
        private const string MENU_BUTTON_PREFAB_PATH = @"UI/Prefabs/MenuButton";
        private const string OBJECT_SPAWNER_BUTTON_PREFAB_PATH = @"UI/Prefabs/ObjectSpawnerButton";
        private const string ABILITY_BUTTON_PREFAB_PATH = @"UI/Prefabs/AbilityButton";
        private const string MENU_BUTTON_DATA_SO_PATH = @"UI/ScriptableObjects/MenuButtonsData";
        private const string OBJECT_SPAWNER_BUTTON_DATA_SO_PATH = @"UI/ScriptableObjects/ObjectSpawnerButtonsData";
        private const string ABILITY_BUTTON_DATA_SO_PATH = @"UI/ScriptableObjects/AbilityButtonsData";

        private MenuButtonView prefabMenuButton;
        private ObjectSpawnerButtonView prefabObjectSpawnerButton;
        private AbilityButtonView prefabAbilityButton;

        private MenuButtonsDataSO menuButtonsDataSO;
        private ObjectSpawnerButtonsDataSO objectSpawnerButtonsDataSO;
        private AbilityButtonsDataSO abilityButtonsDataSO;

        private List<MenuButtonView> menuButtons;
        private List<ObjectSpawnerButtonView> objectSpawnerButtons;
        private List<AbilityButtonView> abilityButtons;

        private List<ButtonBaseView<Enum>> allButtons;
        #endregion

        #region Initialization
        internal ButtonsFactory()
        {
            Load();
            Initialization();
        }

        private void Initialization()
        {
            menuButtons = new();
            objectSpawnerButtons = new();
            abilityButtons = new();
            allButtons = new();
        }

        private void Load()
        {
            prefabMenuButton = Resources.Load<MenuButtonView>(MENU_BUTTON_PREFAB_PATH);
            prefabObjectSpawnerButton = Resources.Load<ObjectSpawnerButtonView>(OBJECT_SPAWNER_BUTTON_PREFAB_PATH);
            prefabAbilityButton = Resources.Load<AbilityButtonView>(ABILITY_BUTTON_PREFAB_PATH);
            menuButtonsDataSO = Resources.Load<MenuButtonsDataSO>(MENU_BUTTON_DATA_SO_PATH);
            objectSpawnerButtonsDataSO = Resources.Load<ObjectSpawnerButtonsDataSO>(OBJECT_SPAWNER_BUTTON_DATA_SO_PATH);
            abilityButtonsDataSO = Resources.Load<AbilityButtonsDataSO>(ABILITY_BUTTON_DATA_SO_PATH);
        }
        #endregion

        #region CreateButton
        private T CreateButton<T, U>(T prefab, Transform parent, U buttonType, bool isLocked, UnityAction action, List<T> buttonList)
            where T : ButtonBaseView<U>
            where U : Enum
        {
            var newButton = GameObject.Instantiate(prefab, parent);
            newButton.Init(buttonType, isLocked, action);
            buttonList.Add(newButton);
            allButtons.Add(newButton as ButtonBaseView<Enum>); // Приводим к базовому типу для хранения в allButtons
            return newButton;
        }

        public MenuButtonView CreateMenuButton(Transform parent, MenuButtonType menuButtonType, bool isLocked, UnityAction action) =>
            CreateButton(prefabMenuButton, parent, menuButtonType, isLocked, action, menuButtons);

        public ObjectSpawnerButtonView CreateObjectSpawnerButton(Transform parent, ObjectSpawnerButtonType objectSpawnerButtonType, bool isLocked, UnityAction action) =>
            CreateButton(prefabObjectSpawnerButton, parent, objectSpawnerButtonType, isLocked, action, objectSpawnerButtons);

        public AbilityButtonView CreateAbilityButton(Transform parent, AbilityButtonType abilityButtonType, bool isLocked, UnityAction action) =>
            CreateButton(prefabAbilityButton, parent, abilityButtonType, isLocked, action, abilityButtons);

        #endregion

        #region UpdateSprites

        public void UpdateSpritesAllButtons()
        {
            UpdateButtonVisuals(objectSpawnerButtons, objectSpawnerButtonsDataSO.ElementConfigs);
            UpdateButtonVisuals(abilityButtons, abilityButtonsDataSO.ElementConfigs);
            UpdateButtonVisuals(menuButtons, menuButtonsDataSO.ElementConfigs);
        }

        private void UpdateButtonVisuals<T, U>(List<T> buttons, List<ElementData<U>> configs)
            where T : ButtonBaseView<U>
            where U : Enum
        {
            if (buttons.Count == 0) return;
            if (configs.Count == 0) return;

            foreach (var button in buttons)
            {
                foreach (var config in configs)
                {
                    if (button.Type.Equals(config.Type))
                    {
                        if (config.VisualData.Sprite is null) continue;
                        button.SetSprite(config.VisualData.Sprite);

                        if(config.VisualData.Text is null) continue;
                        button.SetText(config.VisualData.Text);
                    }
                }
            }
        }
        #endregion
    }
}


