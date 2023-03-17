using RoadGeneration;
using StateMachine;
using UnityEngine;
using Zenject;
using Ecs;
using System;
using Statistics;

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
            BindLevelInitializing();
            BindLevelData();

            BindSystemsFactory();
            //BindStateFactory();

            BindCharacterScore();
            BindScoreIndicator();
        }

        private void BindScoreIndicator()
        {
            Container.Bind<ScoreIndicator>()
                .FromInstance(_scoreIndicator)
                .AsSingle();
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
                .Bind<CharacterScore>()
                .AsSingle();
        }

        private void BindLevelData() //-
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