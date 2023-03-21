using Infrastructure.Menus;
using StateMachines;
using UnityEngine;
using Statistics;
using Zenject;
using Ecs;

namespace Infrastructure.Installers
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private ScoreIndicator _scoreIndicator;
        [SerializeField] private DefeatMenu _defeatMenu;
        [SerializeField] private PauseMenu _pauseMenu;

        public override void InstallBindings()
        {
            BindSystemsInitialization();
            BindSystemsFactory();
            BindSystems();
            BindStateMachine();
            BindStatisticsData();

            BindScoreIndicator();
            BindDefeatMenu();
            BindPauseMenu();
        }

        private void BindSystemsInitialization()
        {
            Container
                .BindInterfacesAndSelfTo<SystemsInitialization>()
                .AsSingle();
        }

        private void BindSystemsFactory()
        {
            Container
                .Bind<SystemsFactory>()
                .AsSingle();
        }

        private void BindSystems()
        {
            Container
                .Bind<Systems>()
                .AsSingle();
        }

        private void BindStateMachine()
        {
            Container
                .Bind<IStateMachine>()
                .FromInstance(new StateMachine(new StateFactory(Container)))
                .AsSingle();
        }

        private void BindStatisticsData()
        {
            Container
                .Bind<StatisticsData>()
                .AsSingle();
        }

        private void BindScoreIndicator()
        {
            Container
                .Bind<ScoreIndicator>()
                .FromInstance(_scoreIndicator)
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
    }
}