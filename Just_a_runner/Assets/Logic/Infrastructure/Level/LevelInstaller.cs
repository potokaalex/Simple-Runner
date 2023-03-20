using StateMachines;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private LevelData _settings;

        public override void InstallBindings()
        {
            BindSystemsInitialization();
            BindStateMachine();
            BindLevelData();

            Container.Bind<Statistics.ScoreIndicator>().FromInstance(_settings.ScoreIndicator).AsSingle();
            Container.Bind<Statistics.CharacterScore>().FromInstance(_settings.CharacterScore).AsSingle();
            Container.Bind<CharacterMarker>().FromInstance(_settings.CharacterMarker).AsSingle();
        }

        private void BindSystemsInitialization()
        {
            Container
                .BindInterfacesTo<SystemsInitialization>()
                .AsSingle();
        }

        private void BindStateMachine()
        {
            Container
                .Bind<IStateMachine>()
                .FromInstance(new StateMachine(new StateFactory(Container)))
                .AsSingle();
        }

        private void BindLevelData()
        {
            Container
                .Bind<LevelData>()
                .FromInstance(_settings)
                .AsSingle();
        }
    }
}