using Assets.Game.Code.Factories.Characters;
using Assets.Game.Code.Startups;
using Zenject;

namespace Assets.Game.Code.Zenject.Installers
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFactories();
        }

        private void BindFactories()
        {
            Container.Bind<ButtonsFactory>()
                .AsSingle();

            //Container.Bind<CharacterFactory>()
            //    .AsSingle();

            Container.Bind<ButtonStartup>()
                .AsSingle()
                .NonLazy();
        }

    }
}
