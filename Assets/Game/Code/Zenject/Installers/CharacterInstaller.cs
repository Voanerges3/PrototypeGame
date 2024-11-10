using Assets.Game.Code.Models.Character;
using Assets.Game.Code.Presenters.Characters;
using Assets.Game.Code.Views.Characters;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Game.Code.Zenject.Installers
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private CharacterView characterPrefab;
        [SerializeField] private Transform characterSpawnPoint;

        public override void InstallBindings()
        {
            BindModels();
            BindPresenters();

            //BindPrefab();
        }

        private void BindModels()
        {
            Container.Bind<CharacterModel>()
                .AsSingle();
        }

        private void BindPresenters()
        {
            Container.BindInterfacesTo<CharacterMovementPresenter>()
                .AsSingle();

            Container.Bind<CharacterDeathPresenter>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<CharacterDamagePresenter>()
                .AsSingle();
            
            //Container.Bind<CreateCharacterPresenter>()
            //    .AsSingle();
        }

        private void BindPrefab()
        {
            var character = Container.InstantiatePrefabForComponent<CharacterView>(characterPrefab, characterSpawnPoint);

            Container.Bind<CharacterView>()
                .FromInstance(character)
                .AsSingle();
        }

    }
}
