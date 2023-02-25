using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MovementSystem
{
    public class CameraTemp : MonoBehaviour
    {
        [SerializeField] private Run _runer;
        [SerializeField] private Vector3 _distance;

        private void FixedUpdate()
        {
            var step = _runer.transform.position + _distance;

            transform.position = step;
        }
    }
}