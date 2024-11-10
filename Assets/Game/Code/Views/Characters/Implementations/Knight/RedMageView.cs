

using Assets.Game.Code.Views.Characters.Abstract;
using UnityEngine;

namespace Assets.Game.Code.Views.Characters.Implementations.Knight
{
    internal class RedMageView : MageBaseView
    {
        private float fireBallRadius;
        private float fireBallDamage;

        public void Init(float fireBallRadius, float fireBallDamage)
        {
            this.fireBallDamage = fireBallDamage;
            this.fireBallRadius = fireBallRadius;
        }
        public override void CastSpell()
        {
            Debug.Log("Огненный шар выпущен");
        }
    }
}
