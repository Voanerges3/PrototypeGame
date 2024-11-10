using Assets.Game.Code.Enums.Characters;
using UnityEngine;

namespace Assets.Game.Code.Factories.Characters
{
    public interface ICharacterFactory
    {
        void Load();
        void Create(CharacterType type, Vector2 position);
    }
}
