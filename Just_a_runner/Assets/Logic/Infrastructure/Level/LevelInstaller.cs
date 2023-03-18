using RoadGeneration;
using StateMachine;
using UnityEngine;
using Statistics;
using Zenject;
using Ecs;

namespace Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private CharacterMarker _characterMarker;
        [SerializeField] private ScoreIndicator _scoreIndicator;
        [SerializeField] private DefeatMenu _defeatMenu;
        [SerializeField] private RoadData _roadData;

        public override void InstallBindings()
        {
            BindSystemsFactory();
            BindStateFactory();

            BindCharacterScore();
            BindScoreIndicator();

            BindCharacterMarker();
            BindDefeatMenu();
            BindRoadData();
        }

        private void BindSystemsFactory()
        {
            Container
                .Bind<SystemsFactory>()
                .AsSingle();
        }

        private void BindStateFactory()
        {
            Container
                .Bind<IStateFactory>()
                .To<StateFactory>()
                .AsSingle();
        }

        private void BindCharacterScore()
        {
            Container
                .Bind<CharacterScore>()
                .AsSingle();
        }

        private void BindScoreIndicator()
        {
            Container
                .Bind<ScoreIndicator>()
                .FromInstance(_scoreIndicator)
                .AsSingle();
        }

        private void BindCharacterMarker()
        {
            Container
                .Bind<CharacterMarker>()
                .FromInstance(_characterMarker)
                .AsSingle();
        }

        private void BindDefeatMenu()
        {
            Container
                .Bind<DefeatMenu>()
                .FromInstance(_defeatMenu)
                .AsSingle();
        }

        private void BindRoadData()
        {
            Container.Bind<RoadData>()
                .FromInstance(_roadData)
                .AsSingle();
        }
    }
}