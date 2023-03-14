using RoadGeneration;
using StateMachine;
using UnityEngine;
using Zenject;
using Ecs;
using System;

namespace Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private CharacterMarker _characterMarker;
        [SerializeField] private DefeatMenu _defeatMenu;
        [SerializeField] private RoadData _roadData;

        public override void InstallBindings()
        {
            BindLevelInitializing();
            BindSystemsFactory();
            BindCharacterScore();
            BindLevelSettings();
            BindStateFactory();
        }

        private void BindLevelInitializing()
        {
            Container
                .BindInterfacesAndSelfTo<LevelInitializing>()
                .AsSingle();
        }

        private void BindSystemsFactory()
        {
            Container
                .Bind<SystemsFactory>()
                .AsSingle();
        }

        private void BindCharacterScore()
        {
            Container
                .Bind<Statistics.CharacterScore>()
                .AsSingle();
        }

        private void BindLevelSettings()
        {
            Container.Bind<CharacterMarker>()
                .FromInstance(_characterMarker)
                .AsSingle();

            Container.Bind<RoadData>()
                .FromInstance(_roadData)
                .AsSingle();

            Container
                .Bind<Systems>()
                .AsSingle();

            Container.Bind<DefeatMenu>()
                .FromInstance(_defeatMenu)
                .AsSingle();
        }

        private void BindStateFactory()
        {
            Container
                .Bind<StateFactory>()
                .AsSingle();
        }
    }
}