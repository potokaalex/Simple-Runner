using UnityEngine;
using Character;
using System;

namespace Infrastructure
{
    [Serializable]
    public class CharacterData
    {
        public GameObject Prefab;
        public Score Score = new();
    }
}
