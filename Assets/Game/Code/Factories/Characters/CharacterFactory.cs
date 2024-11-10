

using Assets.Game.Code.Enums.Characters;
using UnityEngine;
using Zenject;

namespace Assets.Game.Code.Factories.Characters
{
    public sealed class CharacterFactory : ICharacterFactory
    {
        private const string CHARACTER_MAGE_YUKIME_PREFAB_PATH = "Characters/Mage/CharacterMageYukime";

        private readonly DiContainer container;
        private Object characterMageYukimePrefab;

        public CharacterFactory(DiContainer container)
        {
            this.container = container;
            Load();
        }

        public void Load()
        {
            characterMageYukimePrefab = Resources.Load(CHARACTER_MAGE_YUKIME_PREFAB_PATH);
        }

        public void Create(CharacterType type, Vector2 position)
        {
            switch (type)
            {
                case CharacterType.Yukime:
                    container.InstantiatePrefab(characterMageYukimePrefab, position, Quaternion.identity, null);
                    break;
                case CharacterType.Knight:
                    break;
                case CharacterType.Gladiator:
                    break;
            }
        }








        //private IInstantiator container; // под этим интерфейсом прокидывается DIContainer, в нем методы только для создания объектов

        //public CharacterFactory(IInstantiator container)
        //{
        //    this.container = container;
        //}

        //public KnightBaseView CreateKnight() // CharacterBase
        //{
        //    var prefab = Resources.Load<GameObject>("Characters/CharacterGladiator");
        //    var character = GameObject.Instantiate(prefab);
        //    var knight = character.GetComponent<GladiatorKnightView>();
        //    knight.Init(80); // берем из модели характеристики
        //    return knight;
        //}

        //public CharacterViewTest GetCharacterView()
        //{
        //    var prefab = Resources.Load<GameObject>("Characters/CharacterTest");
        //    var instance = container.InstantiatePrefabForComponent<CharacterViewTest>(prefab);
        //    return instance;
        //}
    }
}
