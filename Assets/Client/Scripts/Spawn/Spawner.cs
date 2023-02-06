using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;

namespace SpawnSystem
{
    public class Spawner : IFixedUpdateSystem
    {
        Filter<SpawnRequest> _requests = Filter.Create<SpawnRequest>();

        public void FixedUpdate(float deltaTime)
        {
            foreach (var request in _requests)
                Object.Instantiate(request.SpawnComponent, request.Position,request.Rotation);
        }
    }

    public class SpawnRequest
    {
        public EcsComponent SpawnComponent;
        public Quaternion Rotation;
        public Vector3 Position;



        public SpawnRequest(EcsComponent spawnComponent, Vector3 position, Quaternion rotation)
        {
            SpawnComponent = spawnComponent;
            Rotation = rotation;
            Position = position;
        }
    }
}
