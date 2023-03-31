using Infrastructure.Menus;
using DataManagement;
using UnityEngine;
using Character;
using System;
using Ecs;
using Zenject;
using static Infrastructure.DataProvider;

namespace Infrastructure
{
    [Serializable]
    public class DataProvider
    {
        private SerializableData _serializableData;
        public Score _characterScore;
        public Systems _systems;

        [Serializable]
        public class SerializableData
        {
            public GameObject CharacterPrefab;
            public DefeatMenu DefeatMenu;
            public PauseMenu PauseMenu;
        }

        public DataProvider(SerializableData serializableData, IDataStorage dataStorage)
        {
            _serializableData = serializableData;
            _characterScore = new(dataStorage);
            _systems = new();
        }

        public GameObject CharacterPrefab
            => _serializableData.CharacterPrefab;

        public DefeatMenu DefeatMenu
            => _serializableData.DefeatMenu;

        public PauseMenu PauseMenu
            => _serializableData.PauseMenu;

        public Score CharacterScore
            => _characterScore;

        public Systems Systems
            => _systems;
    }
}
