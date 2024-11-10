


// Ignore Spelling: mana

using UnityEngine;

namespace Assets.Game.Code.Views.Characters.Abstract
{
    internal class CharacterBaseView : MonoBehaviour
    {
        // TODO: Перенести в модель
        [SerializeField] protected int health;

        [SerializeField] protected int mana;

        [SerializeField] protected int healthRegeneration;
        [SerializeField] protected int manaRegeneration;

        [SerializeField] protected int damage;

        [SerializeField] protected int movementSpeed;
        [SerializeField] protected int attackSpeed;

        [SerializeField] protected int magicResistance;
        [SerializeField] protected int physicalResistance;
    }
}
