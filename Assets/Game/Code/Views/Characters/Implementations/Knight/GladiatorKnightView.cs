


// Ignore Spelling: Koef

using Assets.Game.Code.Views.Characters.Abstract;
using UnityEngine;

namespace Assets.Game.Code.Views.Characters.Implementations.Knight
{
    internal class GladiatorKnightView : KnightBaseView
    {
        protected int shieldKoef;

        public void Init(int shieldKoef)
        {
            this.shieldKoef = shieldKoef;
        }
        public override void ActivateShield()
        {
            Debug.Log("Щит поднят.");
        }
    }
}
