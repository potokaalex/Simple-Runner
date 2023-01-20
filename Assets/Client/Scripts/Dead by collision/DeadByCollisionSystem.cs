using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ecs;

namespace Ecs.Systems
{
    public class DeadByCollisionSystem : IUpdateSystem
    {
        private ComponentFilter<DeadByCollision> _deadByCollision = new();

        public void Update(float deltaTime)
        {
            foreach (var component in _deadByCollision)
            {
                var ignoreLayer = 1 << component.CheckBox.gameObject.layer;

                if (IsCollision(component.CheckBox, ~ignoreLayer))
                {
                    Debug.Log("Dead!");
                }
            }
        }

        private bool IsCollision(Transform checkBox, LayerMask layerMask)
            => Physics.CheckBox(checkBox.transform.position, checkBox.transform.lossyScale / 2, checkBox.transform.rotation, layerMask);
    }
}