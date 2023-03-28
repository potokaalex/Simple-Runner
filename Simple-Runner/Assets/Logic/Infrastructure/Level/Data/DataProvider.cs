using Infrastructure.Menus;
using System;
using Ecs;

namespace Infrastructure
{
    [Serializable]
    public class DataProvider
    {
        public CharacterData CharacterData;
        public DefeatMenu DefeatMenu;
        public PauseMenu PauseMenu;

        public Systems Systems = new();
    }
}
