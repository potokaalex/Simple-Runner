using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Ecs.Systems;
//using InputSystem;
//using CollisionSystem;
//using MapGeneration;
using Zenject;

namespace Ecs
{
    public class GameInstaller : MonoInstaller//занимается биндингами
    {
        [SerializeField] private GameStartup _gameStartup;

        public override void InstallBindings()
        {
            //BindGameStartup(_gameStartup);//зачем ? 
        }

        private void BindGameStartup(GameStartup gameStartup)
        {
            Container
                .Bind<GameStartup>()
                .FromInstance(gameStartup)
                .AsSingle();
        }
    }

    public class EcsUpdates : MonoBehaviour
    {


    }
}