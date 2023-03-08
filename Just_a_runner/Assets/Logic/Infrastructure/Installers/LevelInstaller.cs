using RoadGeneration;
using StateMachine;
using UnityEngine;
using Zenject;
using Ecs;

namespace Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private CharacterMarker _characterMarker;
        [SerializeField] private RoadData _roadData;

        public override void InstallBindings()
        {
            BindLevelInitializing();
            BindSystemsFactory();
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
        }

        private void BindStateFactory()
        {
            Container
                .Bind<StateFactory>()
                .AsSingle();
        }
    }
}