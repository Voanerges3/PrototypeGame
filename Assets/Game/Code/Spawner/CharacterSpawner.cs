

using Assets.Game.Code.Factories.Characters;
using System.ComponentModel;
using Zenject;

namespace Assets.Game.Code.Spawner
{
    public sealed class CharacterSpawner //: //IInitializable
    {
        private readonly CharacterFactory characterFactory;

        //[Inject]
        public CharacterSpawner(CharacterFactory characterFactory)
        {
            this.characterFactory = characterFactory;

            
        }

        public void Initialize()
        {
            //throw new System.NotImplementedException();
        }
    }
}
