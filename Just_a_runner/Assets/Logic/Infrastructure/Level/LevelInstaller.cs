using Infrastructure.Menus;
using RoadGeneration;
using StateMachines;
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
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private RoadData _roadData;

        public override void InstallBindings()
        {
            BindSystemsInitialization();
            BindSystemsFactory();
            BindStateMachine();

            BindCharacterScore();
            BindScoreIndicator();

            //level data? (statistics)
            BindCharacterMarker();
            BindDefeatMenu();
            BindPauseMenu();
            BindRoadData();
            BindSystems();
        }

        private void BindSystemsInitialization()
        {
            Container
                .BindInterfacesTo<SystemsInitialization>()
                .AsSingle();
        }

        private void BindSystemsFactory()
        {
            Container
                .Bind<SystemsFactory>()
                .AsSingle();
        }

        private void BindStateMachine()
        {
            Container
                .Bind<IStateMachine>()
                .FromInstance(new StateMachine(new StateFactory(Container)))
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

        private void BindPauseMenu()
        {
            Container
                .Bind<PauseMenu>()
                .FromInstance(_pauseMenu)
                .AsSingle();
        }

        private void BindRoadData()
        {
            Container
                .Bind<RoadData>()
                .FromInstance(_roadData)
                .AsSingle();
        }

        private void BindSystems()
        {
            Container
                .Bind<Systems>()
                .AsSingle();
        }
    }
}