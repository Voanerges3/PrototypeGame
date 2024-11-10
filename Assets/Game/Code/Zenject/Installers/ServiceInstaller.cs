// Ignore Spelling: Zenject

using Assets.Game.Code.Services.GameInput;
using Assets.Game.Code.Services;
using Zenject;
using UnityEngine;

namespace Assets.Game.Code.Zenject.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private ParentService parentService;

        public override void InstallBindings()
        {
            BindServices();
        }

        private void BindServices()
        {
            Container.Bind<ParentService>()
                .FromInstance(parentService)
                .AsSingle();

            Container.Bind<GameInputService>()
                .AsSingle();
        }
    }
}
